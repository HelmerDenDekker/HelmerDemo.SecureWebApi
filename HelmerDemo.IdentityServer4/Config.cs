// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace HelmerDemo.IdentityServer
{
    using System.Collections.Generic;

    using IdentityServer4;
    using IdentityServer4.Models;

    /// <summary>
    /// The config.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// The identity resources.
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        /// <summary>
        /// The API scopes.
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
                {
                    new ApiScope("api", "Secure Web API")
                };

        /// <summary>
        /// The clients.
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // js oidc client
                new Client
                {
                    ClientId = "js_oidc",
                    RedirectUris = new List<string>{ "https://localhost:44301/callback.html" },
                    PostLogoutRedirectUris = new List<string>{"https://localhost:44301/index.html"},
                    AllowedGrantTypes = GrantTypes.Code,
                    // scopes that client has access to
                    AllowedScopes = { IdentityServerConstants.StandardScopes.Email, "api" },
                    AllowedCorsOrigins = new List<string>{"https://localhost:44301"}
                },
                
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    RequirePkce = false,
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:44372/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:44372/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api"
                    },
                    AllowedCorsOrigins = new List<string>{"https://localhost:44732"}
                }
            };
    }
}