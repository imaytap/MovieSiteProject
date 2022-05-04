using MovieSiteProject.Core.Services;

namespace MovieSiteProject.Services.Requests
{
    public class UserUpdateRequest : IRequest
    {
        public Guid Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
