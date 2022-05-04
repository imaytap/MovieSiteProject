﻿using Castle.DynamicProxy;
using MovieSiteProject.Core.Utilities.Interceptors;
using MovieSiteProject.Core.Utilities.IoC;
using System.Diagnostics;

namespace MovieSiteProject.Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private readonly int _interval;
        private readonly Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                var errorMessage = $"Performance : {invocation.Method.DeclaringType?.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}";
                Debug.Write(errorMessage);
            }

            _stopwatch.Reset();
        }
    }
}