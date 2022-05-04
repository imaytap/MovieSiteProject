using Castle.DynamicProxy;

namespace MovieSiteProject.Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        public MethodInterception()
        {
        }

        protected bool Invoke { get; set; } = true;

        protected virtual void OnBefore(IInvocation invocation)
        {
        }

        protected virtual void OnAfter(IInvocation invocation)
        {
        }

        protected virtual void OnException(IInvocation invocation, Exception e)
        {
        }

        protected virtual void OnSuccess(IInvocation invocation)
        {
        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                if (Invoke) invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess) OnSuccess(invocation);
            }

            Invoke = true;
            OnAfter(invocation);
        }
    }
}