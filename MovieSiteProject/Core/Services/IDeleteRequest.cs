namespace MovieSiteProject.Core.Services
{
    public interface IDeleteRequest<TId> : IRequest
    {
        TId Id { get; set; }
    }
}
