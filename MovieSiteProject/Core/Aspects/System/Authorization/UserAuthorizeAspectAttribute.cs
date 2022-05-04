using Microsoft.AspNetCore.Mvc.Filters;
using MovieSiteProject.Core.Exceptions;
using MovieSiteProject.Core.Services.RequestUser;
using MovieSiteProject.Core.Utilities.IoC;

namespace MovieSiteProject.Core.Aspects.System.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserAuthorizeAspectAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IRequestUserService _requestUserService;
        private readonly List<string> _roles;

        public UserAuthorizeAspectAttribute(string roles)
        {
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            roles = roles.Trim();
            roles = roles.ToLower();
            _roles = roles.Split(",").ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var roleClaims = _requestUserService.RequestUser?.Roles;

            if (roleClaims == null)
                throw new AuthorizationException();

            if (roleClaims.Contains("Admin"))
                return;

            foreach (string role in _roles)
            {
                if (roleClaims.Contains(role))
                    return;
            }

            throw new AuthorizationException();
        }
    }
}
