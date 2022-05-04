using MovieSiteProject.Core.Exceptions;

namespace MovieSiteProject.Core.Utilities.Errors
{
    public class AuthorizationErrorDetails : ErrorDetails
    {
        public AuthorizationErrorDetails(string errorMessage) : base(403, errorMessage, ExceptionType.AuthorizationException)
        {
        }

        public AuthorizationErrorDetails(int statusCode, string errorMessage) : base(statusCode, errorMessage, ExceptionType.AuthorizationException)
        {
        }
    }
}
