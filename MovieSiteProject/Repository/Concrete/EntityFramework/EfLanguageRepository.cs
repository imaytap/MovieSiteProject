using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Repository.EntityFramework;
using MovieSiteProject.Repository.Abstract;

namespace MovieSiteProject.Repository.Concrete.EntityFramework
{
    public class EfLanguageRepository : EfEntityRepositoryBase<Language>, ILanguageRepository
    {
    }
}
