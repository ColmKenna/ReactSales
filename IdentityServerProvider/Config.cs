using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServerHost;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource( "ProductScopes", new []{"canEditProducts", "canViewProducts"}),
            new IdentityResource("LocationScopes", new []{"canViewLocations"})
            
//            IdentityResourceExtensions.Create("canEditProducts", "canEditProducts", "canEditProducts"),
//            IdentityResourceExtensions.Create("canViewProducts", "canViewProducts", "canViewProducts"),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("salesapi", "Sales API"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // JavaScript BFF client
            new Client
            {
                ClientId = "bff",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                    
                // where to redirect to after login
                RedirectUris = { "https://localhost:7004/signin-oidc",  "https://localhost:7004/signin-oidc"  },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:7004/signout-callback-oidc", "https://localhost:7004/signout-callback-oidc"  },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "salesapi",
                    "ProductScopes",
                    "LocationScopes"
                }
            }

        };
}