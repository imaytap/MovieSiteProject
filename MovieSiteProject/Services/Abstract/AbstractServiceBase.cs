using MovieSiteProject.Core.CrossCuttingConcerns.Logging.Serilog;
using MovieSiteProject.Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services.RequestUser;
using MovieSiteProject.Core.Utilities.Helpers.FileHelpers;
using MovieSiteProject.Core.Utilities.Helpers.MailHelpers;
using MovieSiteProject.Core.Utilities.IoC;
using MovieSiteProject.Core.Utilities.Security.Jwt;
using MovieSiteProject.Repository.Concrete.EntityFramework;

namespace MovieSiteProject.Services.Abstract
{
    public abstract class AbstractServiceBase
    {
        public AbstractServiceBase()
        {
            HttpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

            MailHelper = ServiceTool.ServiceProvider.GetService<IMailHelper>();
            FileHelper = ServiceTool.ServiceProvider.GetService<IFileHelper>();

            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            UserTokenHelper = ServiceTool.ServiceProvider.GetService<ITokenHelper<User, OperationClaim>>();

            RequestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();

            FileLogger = ServiceTool.ServiceProvider.GetService<FileLogger>();
            MsSqlLogger = ServiceTool.ServiceProvider.GetService<MsSqlLogger>();

            Context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>();
        }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public IMailHelper MailHelper { get; }
        public IFileHelper FileHelper { get; }

        public IConfiguration Configuration { get; }

        public ITokenHelper<User, OperationClaim> UserTokenHelper { get; set; }

        public IRequestUserService RequestUserService { get; set; }

        public LoggerServiceBase FileLogger { get; }
        public LoggerServiceBase MsSqlLogger { get; }

        public ProjectDbContext Context { get; }
    }
}
