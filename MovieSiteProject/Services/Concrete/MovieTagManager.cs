using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class MovieTagManager : AbstractServiceBase, IMovieTagService
    {
        private readonly IMovieTagRepository _movieTagRepository;

        public MovieTagManager(IMovieTagRepository movieTagRepository)
        {
            _movieTagRepository = movieTagRepository;
        }

        public IDataResult<MovieTag> Add(MovieTag entity)
        {
            _movieTagRepository.Add(entity);
            return new SuccessDataResult<MovieTag>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            MovieTag entityToDelete = GetById(entity.Id).Data;
            _movieTagRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<MovieTag>> GetAll()
        {
            return new SuccessDataResult<List<MovieTag>>(_movieTagRepository.GetAll());
        }

        public IDataResult<MovieTag> GetById(Guid id)
        {
            return new SuccessDataResult<MovieTag>(_movieTagRepository.Get(e => e.Id == id));
        }

        public IDataResult<MovieTag> Update(MovieTag entity)
        {
            _movieTagRepository.Update(entity);
            return new SuccessDataResult<MovieTag>(entity);
        }

    }
}
