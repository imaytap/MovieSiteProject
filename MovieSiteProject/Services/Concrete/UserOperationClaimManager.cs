using MovieSiteProject.Core.Aspects.Autofac.Transaction;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class UserOperationClaimManager : AbstractServiceBase, IUserOperationClaimService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IDataResult<UserOperationClaim> Add(UserOperationClaim entity)
        {
            entity.CreatedDate = DateTime.Now;
            _userOperationClaimDal.Add(entity);
            return new SuccessDataResult<UserOperationClaim>(entity);
        }

        [TransactionScopeAspect]
        public IResult Delete(DeleteRequest entity)
        {
            var entityToDelete = GetById(entity.Id).Data;
            _userOperationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        public IDataResult<UserOperationClaim> GetById(Guid id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(e => e.Id == id));
        }

        public IDataResult<UserOperationClaim> Update(UserOperationClaim entity)
        {
            _userOperationClaimDal.Update(entity);
            return new SuccessDataResult<UserOperationClaim>(entity);
        }
    }
}
