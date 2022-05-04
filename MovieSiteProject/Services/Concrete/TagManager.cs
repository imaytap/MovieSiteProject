using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class TagManager : AbstractServiceBase, ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagManager(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IDataResult<Tag> Add(Tag entity)
        {
            _tagRepository.Add(entity);
            return new SuccessDataResult<Tag>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            Tag entityToDelete = GetById(entity.Id).Data;
            _tagRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Tag>> GetAll()
        {
            return new SuccessDataResult<List<Tag>>(_tagRepository.GetAll());
        }

        public IDataResult<Tag> GetById(Guid id)
        {
            return new SuccessDataResult<Tag>(_tagRepository.Get(e => e.Id == id));
        }

        public IDataResult<Tag> Update(Tag entity)
        {
            _tagRepository.Update(entity);
            return new SuccessDataResult<Tag>(entity);
        }

    }
}
