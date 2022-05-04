using MovieSiteProject.Core.Services;

namespace MovieSiteProject.Services.Requests
{
    public class DeleteRequest : IDeleteRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
