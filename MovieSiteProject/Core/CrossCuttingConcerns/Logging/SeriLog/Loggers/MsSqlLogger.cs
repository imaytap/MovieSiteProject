using MovieSiteProject.Core.CrossCuttingConcerns.Logging.Serilog;
using MovieSiteProject.Core.Utilities.IoC;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace MovieSiteProject.Core.CrossCuttingConcerns.Logging.SeriLog.Loggers
{
    public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger()
        {
            IConfiguration configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            MsSqlConfiguration logConfig = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>() ?? throw new Exception("");
            MSSqlServerSinkOptions sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true };

            ColumnOptions columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Message);
            columnOpts.Store.Remove(StandardColumn.Properties);

            Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(logConfig.ConnectionString, sinkOpts, columnOptions: columnOpts)
                .CreateLogger();
        }
    }

    public class MsSqlConfiguration
    {
        public string ConnectionString { get; set; }
    }
}