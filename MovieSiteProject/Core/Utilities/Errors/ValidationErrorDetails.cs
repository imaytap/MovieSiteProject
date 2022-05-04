using MovieSiteProject.Core.Exceptions;

namespace MovieSiteProject.Core.Utilities.Errors
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public ValidationErrorDetails(string errorMessage, List<string> validationErrors) : base(400, errorMessage, ExceptionType.ValidationException)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationErrorDetails(int statusCode, string errorMessage, List<string> validationErrors) : base(statusCode, errorMessage, ExceptionType.ValidationException)
        {
            ValidationErrors = validationErrors;
        }

        public List<string> ValidationErrors { get; set; }
    }
}
