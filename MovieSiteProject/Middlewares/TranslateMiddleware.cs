using Microsoft.Extensions.Primitives;
using MovieSiteProject.Core.Utilities.Contexts.Translate;
using MovieSiteProject.Services.Abstract;

namespace MovieSiteProject.Middlewares
{
    public class TranslateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITranslateContext _translateContext;
        private readonly ITranslateService _translateService;

        public TranslateMiddleware(RequestDelegate next, ITranslateService translateService, ITranslateContext translateContext)
        {
            _next = next;
            _translateService = translateService;
            _translateContext = translateContext;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            StringValues lang;

            if (context.Request.Headers.TryGetValue("lang", out lang))
                _translateContext.Translates = _translateService.GetTranslatesWithLanguageCode(lang).Data;
            else
                _translateContext.Translates = _translateService.GetTranslatesWithLanguageCode("en-US").Data;

            await _next.Invoke(context);
        }
    }
}