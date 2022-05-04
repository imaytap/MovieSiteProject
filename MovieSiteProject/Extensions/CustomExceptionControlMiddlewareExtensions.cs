using MovieSiteProject.Middlewares;

namespace MovieSiteProject.Extensions
{
    public static class CustomExceptionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionControlMiddleware>();
        }
    }
}