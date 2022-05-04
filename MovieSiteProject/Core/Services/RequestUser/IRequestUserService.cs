using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Core.Services.RequestUser
{
    public interface IRequestUserService
    {
        RequestUser RequestUser { get; set; }
        IResult CheckIfRequestUserIsNotEqualsUser(Guid id);
        IResult CheckIfRequestUserIsNotEqualsUser(string email);
    }
}