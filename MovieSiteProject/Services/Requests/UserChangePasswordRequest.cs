using MovieSiteProject.Core.Services;

namespace MovieSiteProject.Services.Requests
{
    public class UserChangePasswordRequest : IRequest
    {
        public Guid Id { get; set; }
        public string NewPassword { get; set; }
    }
}
