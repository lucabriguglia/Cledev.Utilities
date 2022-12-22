using Cledev.Core.Utilities;
using Microsoft.AspNetCore.Http;

namespace Cledev.Server.Services;

public interface IUserService
{
    string? GetCurrentIdentityUserId();
}

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetCurrentIdentityUserId()
    {
        var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
        if (claimsPrincipal?.Identity is null || !claimsPrincipal.Identity.IsAuthenticated)
        {
            return null;
        }

        var identityUserId = claimsPrincipal.GetUserId();
        return string.IsNullOrEmpty(identityUserId) ? null : identityUserId;
    }
}
