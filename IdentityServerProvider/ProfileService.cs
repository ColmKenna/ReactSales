using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityServerHost.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerHost;

public class ProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        context.IssuedClaims.AddRange(context.Subject.Claims);

        return Task.FromResult(0);
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.FromResult(0);
    }
}