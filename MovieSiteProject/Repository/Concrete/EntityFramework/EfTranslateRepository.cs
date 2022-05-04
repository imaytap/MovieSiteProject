using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Repository.EntityFramework;
using MovieSiteProject.Core.Utilities.IoC;
using MovieSiteProject.Dtos;
using MovieSiteProject.Repository.Abstract;

namespace MovieSiteProject.Repository.Concrete.EntityFramework
{
    public class EfTranslateRepository : EfEntityRepositoryBase<Translate>, ITranslateRepository
    {
        public List<TranslateDetails> GetAllTranslatesDetails()
        {
            using (var context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>())
            {
                var result = from translate in context.Translates
                             join language in context.Languages
                             on translate.LanguageId equals language.Id
                             join translateKey in context.TranslateKeys
                             on translate.TranslateKeyId equals translateKey.Id
                             select new TranslateDetails()
                             {
                                 Id = translate.Id,
                                 LanguageId = language.Id,
                                 TranslateKeyId = translateKey.Id,
                                 CreatedDate = translate.CreatedDate,
                                 UpdatedDate = translate.UpdatedDate,
                                 Value = translate.Value,
                                 Language = language.Name,
                                 TranslateKey = translateKey.Key
                             };

                return result.ToList();
            }
        }
    }
}
