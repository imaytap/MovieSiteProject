using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Services.Abstract
{
    public interface ITranslateKeyService : IServiceRepository<TranslateKey, DeleteRequest, Guid>
    {
        IDataResult<TranslateKey> GetByKey(string key);
    }
}
