using MovieSiteProject.Middlewares;

namespace MovieSiteProject.Extensions
{
    public static class TranslateMiddlewareExtensions
    {
        public static IApplicationBuilder UseTranslates(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TranslateMiddleware>();
        }
    }
}