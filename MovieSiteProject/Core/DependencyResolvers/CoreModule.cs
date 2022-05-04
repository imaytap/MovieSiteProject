using MovieSiteProject.Core.CrossCuttingConcerns.Caching;
using MovieSiteProject.Core.CrossCuttingConcerns.Caching.Microsoft;
using MovieSiteProject.Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services.RequestUser;
using MovieSiteProject.Core.Utilities.Contexts.Translate;
using MovieSiteProject.Core.Utilities.Helpers.FileHelpers;
using MovieSiteProject.Core.Utilities.Helpers.MailHelpers;
using MovieSiteProject.Core.Utilities.IoC;
using MovieSiteProject.Core.Utilities.Security.Jwt;
using System.Diagnostics;

namespace MovieSiteProject.Core.DependencyResolvers
{
    public class CoreModule : IModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<Stopwatch>();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();

            serviceCollection.AddSingleton<ITranslateContext, TranslateContext>();

            serviceCollection.AddScoped<IRequestUserService, RequestUserManager>();

            serviceCollection.AddSingleton<IFileHelper, RootFileHelper>();
            serviceCollection.AddSingleton<IMailHelper, SmtpMailHelper>();

            serviceCollection.AddSingleton<ITokenHelper<User, OperationClaim>, JwtHelper>();

            serviceCollection.AddSingleton<FileLogger>();
            serviceCollection.AddSingleton<MsSqlLogger>();
        }
    }
}
