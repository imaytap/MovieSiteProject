using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class ActorManager : AbstractServiceBase, IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorManager(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public IDataResult<Actor> Add(Actor entity)
        {
            _actorRepository.Add(entity);
            return new SuccessDataResult<Actor>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            Actor entityToDelete = GetById(entity.Id).Data;
            _actorRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Actor>> GetAll()
        {
            return new SuccessDataResult<List<Actor>>(_actorRepository.GetAll());
        }

        public IDataResult<Actor> GetById(Guid id)
        {
            return new SuccessDataResult<Actor>(_actorRepository.Get(e => e.Id == id));
        }

        public IDataResult<Actor> Update(Actor entity)
        {
            _actorRepository.Update(entity);
            return new SuccessDataResult<Actor>(entity);
        }
    }
}
