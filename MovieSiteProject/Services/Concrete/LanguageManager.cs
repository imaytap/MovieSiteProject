using MovieSiteProject.Core.Aspects.Autofac.Transaction;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class LanguageManager : AbstractServiceBase, ILanguageService
    {
        private readonly ILanguageRepository _languageDal;

        public LanguageManager(ILanguageRepository languageDal)
        {
            _languageDal = languageDal;
        }

        [TransactionScopeAspect]
        public IDataResult<Language> Add(Language entity)
        {
            var result = BusinessRules.Run(CheckIfLanguageAlreadyExists(entity));
            if (!result.Success)
                return new ErrorDataResult<Language>(result.FirstError.Message);

            entity.CreatedDate = DateTime.Now;
            _languageDal.Add(entity);
            return new SuccessDataResult<Language>(entity);
        }

        [TransactionScopeAspect]
        public IResult Delete(DeleteRequest entity)
        {
            var entityToDelete = GetById(entity.Id).Data;
            _languageDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll());
        }

        public IDataResult<Language> GetByCode(string code)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(e => e.Code.ToLower() == code.ToLower()));
        }

        public IDataResult<Language> GetById(Guid id)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(e => e.Id == id));
        }

        public IDataResult<Language> GetByName(string name)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(e => e.Name.ToLower() == name.ToLower()));
        }

        [TransactionScopeAspect]
        public IDataResult<Language> Update(Language entity)
        {
            var result = BusinessRules.Run(CheckIfLanguageAlreadyExists(entity));
            if (!result.Success)
                return new ErrorDataResult<Language>(result.FirstError.Message);

            _languageDal.Update(entity);
            return new SuccessDataResult<Language>(entity);
        }

        private IResult CheckIfLanguageAlreadyExists(Language entity)
        {
            if (entity.Id == null)
            {
                var language = GetByCode(entity.Code).Data;
                if (language != null)
                    return new ErrorResult("Dil zaten mevcut");

                language = GetByName(entity.Name).Data;
                if (language != null)
                    return new ErrorResult("Dil zaten mevcut");
            }
            else
            {
                var language = GetByCode(entity.Code).Data;
                if (language != null && language.Id != entity.Id)
                    return new ErrorResult("Dil zaten mevcut");

                language = GetByName(entity.Name).Data;
                if (language != null && language.Id != entity.Id)
                    return new ErrorResult("Dil zaten mevcut");
            }

            return new SuccessResult();
        }
    }
}
