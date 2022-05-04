using MovieSiteProject.Core.Exceptions;
using MovieSiteProject.Core.Utilities.Errors;
using MovieSiteProject.Core.Utilities.Results;
using System.Net;

namespace MovieSiteProject.Middlewares
{
    public class CustomExceptionControlMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";

            if (e.GetType() == typeof(ValidationException))
            {
                ValidationException exception = (ValidationException)e;
                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ErrorDataResult<ValidationErrorDetails>(new ValidationErrorDetails(httpContext.Response.StatusCode, exception.ErrorMessage, exception.Errors), exception.ErrorMessage).ToJson());
            }
            else if (e.GetType() == typeof(AuthorizationException))
            {
                AuthorizationException exception = (AuthorizationException)e;
                httpContext.Response.StatusCode = 403;

                return httpContext.Response.WriteAsync(new ErrorDataResult<AuthorizationErrorDetails>(new AuthorizationErrorDetails(httpContext.Response.StatusCode, exception.Error), exception.Error).ToJson());
            }
            else if (e.GetType() == typeof(TransactionException))
            {
                TransactionException exception = (TransactionException)e;
                httpContext.Response.StatusCode = 500;

                return httpContext.Response.WriteAsync(new ErrorDataResult<TransactionErrorDetails>(new TransactionErrorDetails(httpContext.Response.StatusCode, exception.Error), exception.Error).ToJson());
            }

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string exceptionMessage = "Internal Server Error";

            return httpContext.Response.WriteAsync(new ErrorDataResult<ErrorDetails>(new ErrorDetails(httpContext.Response.StatusCode, exceptionMessage, ExceptionType.SystemException), exceptionMessage).ToJson());
        }
    }
}
