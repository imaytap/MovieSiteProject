using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Repository;
using MovieSiteProject.Dtos;

namespace MovieSiteProject.Repository.Abstract
{
    public interface ITranslateRepository : IEntityRepository<Translate>
    {
        List<TranslateDetails> GetAllTranslatesDetails();
    }
}
