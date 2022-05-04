using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface ILanguageService : IServiceRepository<Language, DeleteRequest, Guid>
    {
        IDataResult<Language> GetByCode(string code);
        IDataResult<Language> GetByName(string name);
    }
}
