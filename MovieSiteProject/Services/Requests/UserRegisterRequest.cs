using MovieSiteProject.Core.Services;

namespace MovieSiteProject.Services.Requests
{
    public class UserRegisterRequest : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
