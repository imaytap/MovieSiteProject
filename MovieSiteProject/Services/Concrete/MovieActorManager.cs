using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class MovieActorManager : AbstractServiceBase, IMovieActorService
    {
        private readonly IMovieActorRepository _movieActorRepository;

        public MovieActorManager(IMovieActorRepository movieActorRepository)
        {
            _movieActorRepository = movieActorRepository;
        }

        public IDataResult<MovieActor> Add(MovieActor entity)
        {
            _movieActorRepository.Add(entity);
            return new SuccessDataResult<MovieActor>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            MovieActor entityToDelete = GetById(entity.Id).Data;
            _movieActorRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<MovieActor>> GetAll()
        {
            return new SuccessDataResult<List<MovieActor>>(_movieActorRepository.GetAll());
        }

        public IDataResult<MovieActor> GetById(Guid id)
        {
            return new SuccessDataResult<MovieActor>(_movieActorRepository.Get(e => e.Id == id));
        }

        public IDataResult<MovieActor> Update(MovieActor entity)
        {
            _movieActorRepository.Update(entity);
            return new SuccessDataResult<MovieActor>(entity);
        }
    }
}
