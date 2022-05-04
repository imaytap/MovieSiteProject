using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MovieSiteProject.Core.Utilities.Interceptors;
using MovieSiteProject.Helpers;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Repository.Concrete.EntityFramework;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Concrete;
using System.Reflection;
using Module = Autofac.Module;

namespace DependencyResolvers.Autofac
{
    public class AutofacProjectModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region System Dependencies
            builder.RegisterType<EfLanguageRepository>().As<ILanguageRepository>().SingleInstance();
            builder.RegisterType<EfTranslateKeyRepository>().As<ITranslateKeyRepository>().SingleInstance();
            builder.RegisterType<EfTranslateRepository>().As<ITranslateRepository>().SingleInstance();

            builder.RegisterType<EfOperationClaimRepository>().As<IOperationClaimRepository>().SingleInstance();
            builder.RegisterType<EfUserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimRepository>().As<IUserOperationClaimRepository>().SingleInstance();
            builder.RegisterType<EfRefreshTokenRepository>().As<IRefreshTokenRepository>().SingleInstance();


            builder.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builder.RegisterType<TranslateKeyManager>().As<ITranslateKeyService>().SingleInstance();
            builder.RegisterType<TranslateManager>().As<ITranslateService>().SingleInstance();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<RefreshTokenManager>().As<IRefreshTokenService>().SingleInstance();

            builder.RegisterType<RefreshTokenHelper>().As<IRefreshTokenHelper>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            #endregion
        }
    }
}
