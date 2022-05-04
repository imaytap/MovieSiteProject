using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class CommentsController : ServiceController<Comment, DeleteRequest, Guid>
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService) : base(commentService)
        {
            _commentService = commentService;
        }
    }
}
