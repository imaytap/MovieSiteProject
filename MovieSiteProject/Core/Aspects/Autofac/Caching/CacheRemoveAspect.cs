using Castle.DynamicProxy;
using MovieSiteProject.Core.CrossCuttingConcerns.Caching;
using MovieSiteProject.Core.Utilities.Interceptors;
using MovieSiteProject.Core.Utilities.IoC;

namespace MovieSiteProject.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private readonly string _pattern;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}