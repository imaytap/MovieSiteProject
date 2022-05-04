namespace MovieSiteProject.Core.Utilities.IoC
{
    public interface IModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
