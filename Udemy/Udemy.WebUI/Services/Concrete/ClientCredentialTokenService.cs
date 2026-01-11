using Humanizer;
using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Udemy.IdentityServer.Settings;
using Udemy.WebUI.Services.Interfaces;
using Udemy.WebUI.Settings;

namespace Udemy.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccesTokenCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccesTokenCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _clientAccesTokenCache = clientAccesTokenCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            const string cacheKey = "udemyToken";

            var parameters = new ClientAccessTokenParameters();

            var currentToken = await _clientAccesTokenCache.GetAsync(
                cacheKey,
                parameters
            );

            if (currentToken != null)
            {
                return currentToken.AccessToken;
            }

            var discovery = await _httpClient.GetDiscoveryDocumentAsync(
                new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl
                }
            );

            var request = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.UdemyVisitorClient.ClientId,
                ClientSecret = _clientSettings.UdemyVisitorClient.ClientSecret,
                Address = discovery.TokenEndpoint
            };

            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(request);

            await _clientAccesTokenCache.SetAsync(
                cacheKey,
                newToken.AccessToken,
                newToken.ExpiresIn,
                parameters
            );

            return newToken.AccessToken;
        }

    }
}
