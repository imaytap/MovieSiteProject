using MovieSiteProject.Core.Exceptions;

namespace MovieSiteProject.Core.Utilities.Errors
{
    public class TransactionErrorDetails : ErrorDetails
    {
        public TransactionErrorDetails(string errorMessage) : base(400, errorMessage, ExceptionType.TransactionException)
        {
        }

        public TransactionErrorDetails(int statusCode, string errorMessage) : base(statusCode, errorMessage, ExceptionType.TransactionException)
        {
        }
    }
}
