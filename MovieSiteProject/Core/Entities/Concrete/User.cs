using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Core.Entities.Concrete
{
    public class User : BaseEntity<Guid>
    {
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}