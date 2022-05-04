using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Dtos;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class UserManager : AbstractServiceBase, IUserService
    {
        private readonly IUserRepository _userDal;
        private readonly IOperationClaimService _operationClaimService;

        public UserManager(IUserRepository userDal, IOperationClaimService operationClaimService)
        {
            _userDal = userDal;
            _operationClaimService = operationClaimService;
        }

        public IDataResult<User> Add(User entity)
        {
            entity.CreatedDate = DateTime.Now;
            _userDal.Add(entity);
            return new SuccessDataResult<User>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            var entityToDelete = GetById(entity.Id).Data;
            _userDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(e => e.Email == email));
        }

        public IDataResult<User> GetById(Guid id)
        {
            return new SuccessDataResult<User>(_userDal.Get(e => e.Id == id));
        }

        public IDataResult<List<User>> GetByStatus(bool status)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(e => e.Status == status));
        }

        public IDataResult<List<OperationClaim>> GetClaims(Guid userId)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(userId));
        }

        public IDataResult<List<UserOperationClaimDetails>> GetClaimsWithDetails(Guid userId)
        {
            return new SuccessDataResult<List<UserOperationClaimDetails>>(_userDal.GetClaimsWithDetails(userId));
        }

        public IDataResult<List<OperationClaim>> GetOtherClaims(Guid userId)
        {
            var claims = _operationClaimService.GetAll().Data;
            var otherClaims = new List<OperationClaim>();
            foreach (var claim in claims)
                otherClaims.Add(claim);

            var userClaims = GetClaims(userId).Data;
            foreach (var claim in claims)
                foreach (var userClaim in userClaims)
                    if (claim.Id == userClaim.Id)
                        otherClaims.Remove(claim);

            return new SuccessDataResult<List<OperationClaim>>(otherClaims);
        }

        public IDataResult<User> Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessDataResult<User>(entity);
        }
    }
}
