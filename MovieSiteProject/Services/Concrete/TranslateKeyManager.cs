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
    public class TranslateKeyManager : AbstractServiceBase, ITranslateKeyService
    {
        private readonly ITranslateKeyRepository _translateKeyDal;

        public TranslateKeyManager(ITranslateKeyRepository translateKeyDal)
        {
            _translateKeyDal = translateKeyDal;
        }

        [TransactionScopeAspect]
        public IDataResult<TranslateKey> Add(TranslateKey entity)
        {
            var result = BusinessRules.Run(CheckIfKeyAlreadyExists(entity));
            if (!result.Success)
                return new ErrorDataResult<TranslateKey>(result.FirstError.Message);

            entity.CreatedDate = DateTime.Now;
            _translateKeyDal.Add(entity);
            return new SuccessDataResult<TranslateKey>(entity);
        }

        [TransactionScopeAspect]
        public IResult Delete(DeleteRequest entity)
        {
            var entityToDelete = GetById(entity.Id).Data;
            _translateKeyDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<TranslateKey>> GetAll()
        {
            return new SuccessDataResult<List<TranslateKey>>(_translateKeyDal.GetAll());
        }

        public IDataResult<TranslateKey> GetById(Guid id)
        {
            return new SuccessDataResult<TranslateKey>(_translateKeyDal.Get(e => e.Id == id));
        }

        public IDataResult<TranslateKey> GetByKey(string key)
        {
            return new SuccessDataResult<TranslateKey>(_translateKeyDal.Get(e => e.Key == key));
        }

        [TransactionScopeAspect]
        public IDataResult<TranslateKey> Update(TranslateKey entity)
        {
            var result = BusinessRules.Run(CheckIfKeyAlreadyExists(entity));
            if (!result.Success)
                return new ErrorDataResult<TranslateKey>(result.FirstError.Message);

            _translateKeyDal.Update(entity);
            return new SuccessDataResult<TranslateKey>(entity);
        }

        private IResult CheckIfKeyAlreadyExists(TranslateKey entity)
        {
            if (entity.Id == null)
            {
                var translateKey = GetByKey(entity.Key).Data;
                if (translateKey != null)
                    return new ErrorResult("Key zaten mevcut");
            }
            else
            {
                var translateKey = GetByKey(entity.Key).Data;
                if (translateKey != null && translateKey.Id != entity.Id)
                    return new ErrorResult("Key zaten mevcut");
            }

            return new SuccessResult();
        }
    }
}
