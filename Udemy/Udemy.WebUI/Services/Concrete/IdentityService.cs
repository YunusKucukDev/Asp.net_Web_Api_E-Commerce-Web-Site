using Humanizer;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MongoDB.Driver.Core.Configuration;
using System.Security.Claims;
using Udemy.DtoLayer.IdentityDtos.LoginDtos;
using Udemy.IdentityServer.Settings;
using Udemy.WebUI.Services.Interfaces;
using Udemy.WebUI.Settings;

namespace Udemy.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContexAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContexAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContexAccessor = httpContexAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            var discovery = await _httpClient.GetDiscoveryDocumentAsync(
                _serviceApiSettings.IdentityServerUrl);

            if (discovery.IsError)
                throw new Exception(discovery.Error);

            var httpContext = _httpContexAccessor.HttpContext;

            var refreshToken = await httpContext
                .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            if (string.IsNullOrEmpty(refreshToken))
                return false;

            var tokenResponse = await _httpClient.RequestRefreshTokenAsync(
                new RefreshTokenRequest
                {
                    ClientId = _clientSettings.UdemyManagerClient.ClientId,
                    ClientSecret = _clientSettings.UdemyManagerClient.ClientSecret,
                    RefreshToken = refreshToken,
                    Address = discovery.TokenEndpoint
                });

            if (tokenResponse.IsError)
                throw new Exception(tokenResponse.Error);

            var authResult = await httpContext.AuthenticateAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            var tokens = new List<AuthenticationToken>
    {
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.AccessToken,
            Value = tokenResponse.AccessToken
        },
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.RefreshToken,
            Value = tokenResponse.RefreshToken
        }
    };

            authResult.Properties.StoreTokens(tokens);

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                authResult.Principal,
                authResult.Properties);

            return true;
        }


        public async Task<bool> SignIn(SignInDto dto)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl

            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.UdemyManagerClient.ClientId,
                ClientSecret = _clientSettings.UdemyManagerClient.ClientSecret,
                UserName = dto.Username,
                Password = dto.Password,
                Address = discoveryEndPoint.TokenEndpoint,
               
            };

            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            if (token.IsError)
            {
                throw new Exception(token.ErrorDescription ?? token.Error);
            }

            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };

            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()

                }
            });
            authenticationProperties.IsPersistent = false;

            await _httpContexAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

            return true;
        }
    }
}
