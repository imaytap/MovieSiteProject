using Castle.DynamicProxy;
using MovieSiteProject.Core.Exceptions;
using MovieSiteProject.Core.Extensions;
using MovieSiteProject.Core.Services.RequestUser;
using MovieSiteProject.Core.Utilities.Interceptors;
using MovieSiteProject.Core.Utilities.IoC;

namespace MovieSiteProject.Core.Aspects.Autofac.Authorization
{
    public class SecuredOperation : MethodInterception
    {
        private readonly List<string> _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRequestUserService _requestUserService;

        public SecuredOperation(string roles)
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            roles = roles.Trim();
            roles = roles.ToLower();
            _roles = roles.Split(',').ToList();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _requestUserService.RequestUser?.Roles;

            if (roleClaims == null)
                throw new AuthorizationException();

            if (roleClaims.Contains("Admin"))
                return;

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                    return;
            }

            throw new AuthorizationException();
        }
    }
}
