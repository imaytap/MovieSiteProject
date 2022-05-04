using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Services;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class OperationClaimManager : AbstractServiceBase, IOperationClaimService
    {
        private readonly IOperationClaimRepository _operationClaimDal;

        public OperationClaimManager(IOperationClaimRepository operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IDataResult<OperationClaim> Add(OperationClaim entity)
        {
            var result = BusinessRules.Run(CheckIfOperationClaimAlreadyExists(entity));
            if (!result.Success)
                return new ErrorDataResult<OperationClaim>(result.FirstError.Message);

            entity.CreatedDate = DateTime.Now;
            _operationClaimDal.Add(entity);
            return new SuccessDataResult<OperationClaim>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            var entityToDelete = GetById(entity.Id).Data;
            _operationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        public IDataResult<OperationClaim> GetById(Guid id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(e => e.Id == id));
        }

        public IDataResult<OperationClaim> GetByName(string name)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(e => e.Name.ToLower() == name.ToLower()));
        }

        public IDataResult<OperationClaim> Update(OperationClaim entity)
        {
            var result = BusinessRules.Run(CheckIfOperationClaimAlreadyExists(entity));
            if (!result.Success)
                return new ErrorDataResult<OperationClaim>(result.FirstError.Message);

            _operationClaimDal.Update(entity);
            return new SuccessDataResult<OperationClaim>(entity);
        }
        private IResult CheckIfOperationClaimAlreadyExists(OperationClaim entity)
        {
            if (entity.Id == null)
            {
                var operationClaim = GetByName(entity.Name).Data;
                if (operationClaim != null)
                    return new ErrorResult("Rol zaten mevcut");
            }
            else
            {
                var operationClaim = GetByName(entity.Name).Data;
                if (operationClaim != null && operationClaim.Id != entity.Id)
                    return new ErrorResult("Rol zaten mevcut");
            }

            return new SuccessResult();
        }
    }
}
