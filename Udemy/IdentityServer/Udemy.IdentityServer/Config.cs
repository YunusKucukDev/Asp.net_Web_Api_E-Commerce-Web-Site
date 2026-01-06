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
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
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
                AllowedScopes = {"CatalogFullPermission","CatalogFullPermission"} //Kapsamlar
            },

            //Manager
            new Client
            {
                ClientId ="UdemyManagerId",
                ClientName="Udemy Manager User",
                AllowedGrantTypes =GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("udemySecret".Sha256())},
                AllowedScopes ={ "CatalogReadPermission" , "CatalogFullPermission", "BasketFullPermission" }

            },

            //Admin
             new Client
            {
                ClientId ="UdemyAdminId",
                ClientName="Udemy Admin User",
                AllowedGrantTypes =GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("udemySecret".Sha256())},
                AllowedScopes ={ "CatalogReadPermission" , "CatalogFullPermission","DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission",
                 IdentityServerConstants.LocalApi.ScopeName,
                 IdentityServerConstants.StandardScopes.Email,
                 IdentityServerConstants.StandardScopes.OpenId,
                 IdentityServerConstants.StandardScopes.Profile,
                 },
                AccessTokenLifetime =600

            }
        };
    }
}