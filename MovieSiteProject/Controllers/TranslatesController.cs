using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class TranslatesController : ServiceController<Translate, DeleteRequest, Guid>
    {
        private readonly ITranslateService _translateService;

        public TranslatesController(ITranslateService translateService) : base(translateService)
        {
            _translateService = translateService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByLanguageId(Guid languageId)
        {
            var result = _translateService.GetByLanguageId(languageId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetTranslatesWithLanguageCode(string languageCode)
        {
            var result = _translateService.GetTranslatesWithLanguageCode(languageCode);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetTranslatesWithLanguageId(Guid languageId)
        {
            var result = _translateService.GetTranslatesWithLanguageId(languageId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpGet("[action]")]
        public IActionResult GetAllTranslatesDetails()
        {
            var result = _translateService.GetAllTranslatesDetails();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
