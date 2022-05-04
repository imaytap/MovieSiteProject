using MovieSiteProject.Core.Utilities.IoC;

namespace MovieSiteProject.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, params IModule[] modules)
        {
            foreach (var module in modules) module.Load(serviceCollection);

            return ServiceTool.Create(serviceCollection);
        }
    }
}
