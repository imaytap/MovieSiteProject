namespace MovieSiteProject.Core.Services.RequestUser
{
    public class RequestUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public List<string> Roles { get; set; }
    }
}
