using MovieSiteProject.Core.Utilities.IoC;

namespace MovieSiteProject.DependencyResolvers
{
    public class ProjectModule : IModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSignalR();
        }
    }
}
