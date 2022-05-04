using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class XUserManager : AbstractServiceBase, IXUserService
    {
        private readonly IXUserRepository _xUserRepository;

        public XUserManager(IXUserRepository xUserRepository)
        {
            _xUserRepository = xUserRepository;
        }

        public IDataResult<XUser> Add(XUser entity)
        {
            _xUserRepository.Add(entity);
            return new SuccessDataResult<XUser>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            XUser entityToDelete = GetById(entity.Id).Data;
            _xUserRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<XUser>> GetAll()
        {
            return new SuccessDataResult<List<XUser>>(_xUserRepository.GetAll());
        }

        public IDataResult<XUser> GetById(Guid id)
        {
            return new SuccessDataResult<XUser>(_xUserRepository.Get(e => e.Id == id));
        }

        public IDataResult<XUser> Update(XUser entity)
        {
            _xUserRepository.Update(entity);
            return new SuccessDataResult<XUser>(entity);
        }
    }
}
