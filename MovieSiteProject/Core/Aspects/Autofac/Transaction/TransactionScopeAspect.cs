using Castle.DynamicProxy;
using MovieSiteProject.Core.Utilities.Interceptors;
using System.Transactions;

namespace MovieSiteProject.Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public TransactionScopeAspect()
        {
        }

        public override void Intercept(IInvocation invocation)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();

                    if (e.GetType() == typeof(Exceptions.ValidationException))
                    {
                        throw;
                    }

                    if (e.GetType() == typeof(Exceptions.AuthorizationException))
                    {
                        throw;
                    }

                    throw new Exceptions.TransactionException("Transaction Error");
                }
            }
        }
    }
}