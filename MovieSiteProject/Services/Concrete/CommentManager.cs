using MovieSiteProject.Core.Utilities.Results;
using MovieSiteProject.Entities;
using MovieSiteProject.Repository.Abstract;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Services.Concrete
{
    public class CommentManager : AbstractServiceBase, ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IDataResult<Comment> Add(Comment entity)
        {
            _commentRepository.Add(entity);
            return new SuccessDataResult<Comment>(entity);
        }

        public IResult Delete(DeleteRequest entity)
        {
            Comment entityToDelete = GetById(entity.Id).Data;
            _commentRepository.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentRepository.GetAll());
        }

        public IDataResult<Comment> GetById(Guid id)
        {
            return new SuccessDataResult<Comment>(_commentRepository.Get(e => e.Id == id));
        }

        public IDataResult<Comment> Update(Comment entity)
        {
            _commentRepository.Update(entity);
            return new SuccessDataResult<Comment>(entity);
        }
    }
}
