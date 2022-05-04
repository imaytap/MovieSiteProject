using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Dtos;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface ITranslateService : IServiceRepository<Translate, DeleteRequest, Guid>
    {
        IDataResult<List<Translate>> GetByLanguageId(Guid languageId);
        IDataResult<List<Translate>> GetByTranslateKeyId(Guid translateKeyId);
        IDataResult<Dictionary<string, string>> GetTranslatesWithLanguageCode(string languageCode);
        IDataResult<Dictionary<string, string>> GetTranslatesWithLanguageId(Guid languageId);
        IDataResult<List<TranslateDetails>> GetAllTranslatesDetails();
    }
}
