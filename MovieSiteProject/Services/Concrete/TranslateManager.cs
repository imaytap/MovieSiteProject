using MovieSiteProject.Core.Aspects.Autofac.Transaction;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Dtos;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class TranslateManager : AbstractServiceBase, ITranslateService
    {
        private readonly ITranslateRepository _translateDal;
        private readonly ILanguageService _languageService;
        private readonly ITranslateKeyService _keyService;

        public TranslateManager(ITranslateRepository translateDal, ILanguageService languageService, ITranslateKeyService keyService)
        {
            _translateDal = translateDal;
            _languageService = languageService;
            _keyService = keyService;
        }

        [TransactionScopeAspect]
        public IDataResult<Translate> Add(Translate entity)
        {
            var result = BusinessRules.Run(CheckIfTranslateAlreadyExistsForKeyAndLanguage(entity));
            if (!result.Success)
                return new ErrorDataResult<Translate>(result.FirstError.Message);

            entity.CreatedDate = DateTime.Now;
            _translateDal.Add(entity);
            return new SuccessDataResult<Translate>(entity);
        }

        [TransactionScopeAspect]
        public IResult Delete(DeleteRequest entity)
        {
            var entityToDelete = GetById(entity.Id).Data;
            _translateDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Translate>> GetAll()
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll());
        }

        public IDataResult<List<TranslateDetails>> GetAllTranslatesDetails()
        {
            return new SuccessDataResult<List<TranslateDetails>>(_translateDal.GetAllTranslatesDetails());
        }

        public IDataResult<Translate> GetById(Guid id)
        {
            return new SuccessDataResult<Translate>(_translateDal.Get(e => e.Id == id));
        }

        public IDataResult<List<Translate>> GetByLanguageId(Guid languageId)
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll(e => e.LanguageId == languageId));
        }

        public IDataResult<List<Translate>> GetByTranslateKeyId(Guid translateKeyId)
        {
            return new SuccessDataResult<List<Translate>>(_translateDal.GetAll(e => e.TranslateKeyId == translateKeyId));
        }

        public IDataResult<Dictionary<string, string>> GetTranslatesWithLanguageCode(string languageCode)
        {
            var dictionary = new Dictionary<string, string>();
            var language = _languageService.GetByCode(languageCode).Data;
            if (language == null)
            {
                language = _languageService.GetByCode("en").Data;
            }

            var languageTranslates = GetByLanguageId(language.Id).Data;
            foreach (var languageTranslate in languageTranslates)
            {
                var key = _keyService.GetById(languageTranslate.TranslateKeyId).Data;
                dictionary.Add(key.Key, languageTranslate.Value);
            }

            return new SuccessDataResult<Dictionary<string, string>>(dictionary);
        }

        public IDataResult<Dictionary<string, string>> GetTranslatesWithLanguageId(Guid languageId)
        {
            var dictionary = new Dictionary<string, string>();
            var language = _languageService.GetById(languageId).Data;
            if (language == null)
            {
                language = _languageService.GetByCode("en").Data;
            }

            var languageTranslates = GetByLanguageId(language.Id).Data;
            foreach (var languageTranslate in languageTranslates)
            {
                var key = _keyService.GetById(languageTranslate.TranslateKeyId).Data;
                dictionary.Add(key.Key, languageTranslate.Value);
            }

            return new SuccessDataResult<Dictionary<string, string>>(dictionary);
        }

        [TransactionScopeAspect]
        public IDataResult<Translate> Update(Translate entity)
        {
            var result = BusinessRules.Run(CheckIfTranslateAlreadyExistsForKeyAndLanguage(entity));
            if (!result.Success)
                return new ErrorDataResult<Translate>(result.FirstError.Message);

            _translateDal.Update(entity);
            return new SuccessDataResult<Translate>(entity);
        }

        private IResult CheckIfTranslateAlreadyExistsForKeyAndLanguage(Translate entity)
        {
            if (entity.Id == null)
            {
                var translates = GetByTranslateKeyId(entity.TranslateKeyId).Data;
                foreach (var translate in translates)
                    if (translate.LanguageId == entity.LanguageId)
                        return new ErrorResult("Bu dil ve key için zaten bir çeviri mevcut");
            }
            else
            {
                var translates = GetByTranslateKeyId(entity.TranslateKeyId).Data;
                foreach (var translate in translates)
                    if (translate.LanguageId == entity.LanguageId && translate.Id != entity.Id)
                        return new ErrorResult("Bu dil ve key için zaten bir çeviri mevcut");
            }

            return new SuccessResult();
        }
    }
}
