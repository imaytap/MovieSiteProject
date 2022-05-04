using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class CategoryManager : AbstractServiceBase, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IDataResult<Category> Add(Category entity)
        {
            _categoryRepository.Add(entity);
            return new SuccessDataResult<Category>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            Category entityToDelete = GetById(entity.Id).Data;
            _categoryRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll());
        }

        public IDataResult<Category> GetById(Guid id)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Get(e => e.Id == id));
        }

        public IDataResult<Category> Update(Category entity)
        {
            _categoryRepository.Update(entity);
            return new SuccessDataResult<Category>(entity);
        }
    }
}
