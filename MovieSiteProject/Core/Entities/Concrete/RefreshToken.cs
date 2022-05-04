using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Core.Entities.Concrete
{
    public class RefreshToken : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string TokenValue { get; set; }
        public string RefreshTokenValue { get; set; }
        public virtual User? User { get; set; }
    }
}