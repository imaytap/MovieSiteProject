using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class TranslateKeysController : ServiceController<TranslateKey, DeleteRequest, Guid>
    {
        private readonly ITranslateKeyService _translateKeyService;

        public TranslateKeysController(ITranslateKeyService translateKeyService) : base(translateKeyService)
        {
            _translateKeyService = translateKeyService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByKey(string key)
        {
            var result = _translateKeyService.GetByKey(key);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
