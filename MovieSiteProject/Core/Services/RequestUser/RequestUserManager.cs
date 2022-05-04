using MovieSiteProject.Core.Exceptions;
using MovieSiteProject.Core.Utilities.Results;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Core.Services.RequestUser
{
    public class RequestUserManager : IRequestUserService
    {
        public RequestUser RequestUser { get; set; }

        public IResult CheckIfRequestUserIsNotEqualsUser(Guid userId)
        {
            if (RequestUser != null)
            {
                if (RequestUser.Id != userId)
                    throw new AuthorizationException();

                return new SuccessResult();
            }

            return null;
        }

        public IResult CheckIfRequestUserIsNotEqualsUser(string email)
        {
            if (RequestUser != null)
            {
                if (RequestUser.Email != email)
                    throw new AuthorizationException();

                return new SuccessResult();
            }

            return null;
        }
    }
}