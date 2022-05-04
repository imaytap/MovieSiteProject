using MovieSiteProject.Core.Services;

namespace MovieSiteProject.Services.Requests
{
    public class UserRegisterForAdminRequest : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
