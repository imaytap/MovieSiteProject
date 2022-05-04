using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class MovieManager : AbstractServiceBase, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IDataResult<Movie> Add(MovieAddRequest entity)
        {
            var movie = new Movie()
            {
                XUserId = entity.XUserId,
                Name = entity.Name,
                Description = entity.Description,
                Slug = entity.Slug,
                ImagePath = FileHelper.CreateFile(entity.Image),
                VideoPath = FileHelper.CreateFile(entity.Video),
                CreatedDate = DateTime.Now,
            };

            _movieRepository.Add(movie);
            return new SuccessDataResult<Movie>(movie);
        }

        public IResult Delete(DeleteRequest entity)
        {
            Movie entityToDelete = GetById(entity.Id).Data;
            _movieRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieRepository.GetAll());
        }

        public IDataResult<Movie> GetById(Guid id)
        {
            return new SuccessDataResult<Movie>(_movieRepository.Get(e => e.Id == id));
        }

        public IDataResult<Movie> Update(Movie entity)
        {
            _movieRepository.Update(entity);
            return new SuccessDataResult<Movie>(entity);
        }
    }
}
