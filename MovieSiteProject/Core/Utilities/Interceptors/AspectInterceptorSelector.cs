using Castle.DynamicProxy;
using MovieSiteProject.Core.Aspects.Autofac.Logging;
using MovieSiteProject.Core.Aspects.Autofac.Performance;
using MovieSiteProject.Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using System.Reflection;

namespace MovieSiteProject.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            if (methodAttributes != null)
            {
                classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
                classAttributes.Add(new ExceptionLogAspect(typeof(MsSqlLogger)));
                classAttributes.Add(new PerformanceAspect(10));
                classAttributes.AddRange(methodAttributes);
            }

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}