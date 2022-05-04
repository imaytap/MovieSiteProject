using Castle.DynamicProxy;
using MovieSiteProject.Core.CrossCuttingConcerns.Logging;
using MovieSiteProject.Core.CrossCuttingConcerns.Logging.Serilog;
using MovieSiteProject.Core.Utilities.Interceptors;
using MovieSiteProject.Core.Utilities.IoC;
using Newtonsoft.Json;

namespace MovieSiteProject.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new ArgumentException();

            _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase?.Info(GetLogDetail(invocation));
        }

        private string GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (var i = 0; i < invocation.Arguments.Length; i++)
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod()?.GetParameters()?[i]?.Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });

            var methodName = invocation.MethodInvocationTarget.DeclaringType?.FullName + "." + invocation.Method.Name;

            var logDetail = new LogDetail
            {
                MethodName = methodName,
                Parameters = logParameters,
            };

            return JsonConvert.SerializeObject(logDetail);
        }
    }
}