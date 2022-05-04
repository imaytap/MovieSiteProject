using Castle.DynamicProxy;
using MovieSiteProject.Core.CrossCuttingConcerns.Logging;
using MovieSiteProject.Core.CrossCuttingConcerns.Logging.Serilog;
using MovieSiteProject.Core.Utilities.Interceptors;
using Newtonsoft.Json;

namespace MovieSiteProject.Core.Aspects.Autofac.Logging
{
    public class ExceptionLogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new ArgumentException();

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            var logDetailWithException = GetLogDetail(invocation, e);
            logDetailWithException.ExceptionMessage = e is AggregateException
                ? string.Join(Environment.NewLine, (e as AggregateException).InnerExceptions.Select(x => x.Message))
                : e.Message;

            _loggerServiceBase.Error(JsonConvert.SerializeObject(logDetailWithException));
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation, Exception e)
        {
            var logParameters = invocation.Arguments.Select((t, i) => new LogParameter
            { Name = invocation.GetConcreteMethod()?.GetParameters()?[i]?.Name, Value = t, Type = t?.GetType().Name }).ToList();
            var methodName = invocation.MethodInvocationTarget.DeclaringType?.FullName + "." + invocation.Method.Name;

            return new LogDetailWithException
            {
                MethodName = methodName,
                ExceptionMessage = e.Message
            };
        }
    }
}