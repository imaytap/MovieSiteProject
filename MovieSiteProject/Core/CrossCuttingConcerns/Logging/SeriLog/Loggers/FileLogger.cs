using MovieSiteProject.Core.CrossCuttingConcerns.Logging.Serilog;
using MovieSiteProject.Core.Utilities.IoC;
using Serilog;
using System.Text;

namespace MovieSiteProject.Core.CrossCuttingConcerns.Logging.SeriLog.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger()
        {
            IConfiguration configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            FileLogConfiguration logConfig = configuration.GetSection("SeriLogConfigurations:FileLogConfiguration").Get<FileLogConfiguration>() ?? throw new Exception("");

            string logFilePath = string.Format("{0}{1}", Directory.GetCurrentDirectory() + logConfig.FolderPath, ".txt");

            Logger = new LoggerConfiguration()
                .WriteTo.File(
                    logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: 5000000,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
                    encoding: Encoding.UTF8)
                .CreateLogger();
        }
    }

    public class FileLogConfiguration
    {
        public string FolderPath { get; set; }
    }
}