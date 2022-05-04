using MovieSiteProject.Core.Controllers;
using MovieSiteProject.Entities;
using MovieSiteProject.Services.Abstract;
using MovieSiteProject.Services.Requests;

namespace MovieSiteProject.Controllers
{
    public class XUsersController : ServiceController<XUser, DeleteRequest, Guid>
    {
        private readonly IXUserService _xUserService;

        public XUsersController(IXUserService xUserService) : base(xUserService)
        {
            _xUserService = xUserService;
        }
    }
}
