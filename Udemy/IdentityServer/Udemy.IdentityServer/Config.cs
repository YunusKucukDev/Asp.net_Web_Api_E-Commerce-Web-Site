// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace Udemy.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes ={"CatalogFullPermission","CatalogReadPermission" }},
            new ApiResource("ResourceDiscount"){Scopes ={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes ={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes ={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes ={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes ={"CommentFullPermission"}},
            new ApiResource("ResourcePayment"){Scopes ={"PaymentFullPermission"}},
            new ApiResource("ResourceImages"){Scopes ={"ImagesFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes ={"OcelotFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes ={"MessageFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            // Kullanıcını ilgili yetkide hangi işlemleri yapabildiğini belirler .
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for Cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for basket operations"),
            new ApiScope("CommentFullPermission","Full authority for Comment operations"),
            new ApiScope("PaymentFullPermission","Full authority for Payment operations"),
            new ApiScope("ImagesFullPermission","Full authority for Images operations"),
            new ApiScope("MessageFullPermission","Full authority for Message operations"),
            new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            new ApiScope(IdentityServerConstants.StandardScopes.OfflineAccess)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            new Client
            {
                ClientId="UdemyVisitorId",
                ClientName ="Udemy Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials, // Neye izin verdiğiyle ilgili property
                ClientSecrets ={new Secret("udemySecret".Sha256())},
                AllowedScopes = {"CatalogFullPermission","OcelotFullPermission","CommentFullPermission", "ImagesFullPermission",} //Kapsamlar
            },

            //Manager
           new Client
            {
                ClientId = "UdemyManagerId",
                ClientName = "Udemy Manager User",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("udemySecret".Sha256()) },

                AllowedScopes =
                {
                    "ImagesFullPermission",
                    "CatalogReadPermission",
                    "CatalogFullPermission",
                    "BasketFullPermission",
                    "DiscountFullPermission",
                    "OcelotFullPermission",
                    "CommentFullPermission",
                    "PaymentFullPermission",
                    "OrderFullPermission",
                    "MessageFullPermission",
                    "CargoFullPermission",

                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OfflineAccess
                },

                AllowOfflineAccess = true
            },

            new Client
            {
                ClientId = "UdemyAdminId",
                ClientName = "Udemy Admin User",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("udemySecret".Sha256()) },

                AllowedScopes =
                {
                    "OcelotFullPermission",
                    "ImagesFullPermission",
                    "PaymentFullPermission",
                    "CatalogReadPermission",
                    "CatalogFullPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    "CommentFullPermission",
                    "CargoFullPermission",

                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OfflineAccess
                },

                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 600
                }

        };
    }
}