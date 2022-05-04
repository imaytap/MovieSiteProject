using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class MovieCategoryManager : AbstractServiceBase, IMovieCategoryService
    {
        private readonly IMovieCategoryRepository _movieCategoryRepository;

        public MovieCategoryManager(IMovieCategoryRepository movieCategoryRepository)
        {
            _movieCategoryRepository = movieCategoryRepository;
        }

        public IDataResult<MovieCategory> Add(MovieCategory entity)
        {
            _movieCategoryRepository.Add(entity);
            return new SuccessDataResult<MovieCategory>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            MovieCategory entityToDelete = GetById(entity.Id).Data;
            _movieCategoryRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<MovieCategory>> GetAll()
        {
            return new SuccessDataResult<List<MovieCategory>>(_movieCategoryRepository.GetAll());
        }

        public IDataResult<MovieCategory> GetById(Guid id)
        {
            return new SuccessDataResult<MovieCategory>(_movieCategoryRepository.Get(e => e.Id == id));
        }

        public IDataResult<MovieCategory> Update(MovieCategory entity)
        {
            _movieCategoryRepository.Update(entity);
            return new SuccessDataResult<MovieCategory>(entity);
        }

    }
}
