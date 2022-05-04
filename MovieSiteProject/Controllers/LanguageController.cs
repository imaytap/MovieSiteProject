using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Aspects.System.Authorization;
using MovieSiteProject.Core.Aspects.System.Validation;
using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class LanguagesController : ServiceController<Language, DeleteRequest, Guid>
    {
        private readonly ILanguageService _languageService;
        public LanguagesController(ILanguageService languageService) : base(languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByCode(string code)
        {
            var result = _languageService.GetByCode(code);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetByName(string name)
        {
            var result = _languageService.GetByName(name);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
