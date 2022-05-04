using MovieSiteProject.Core.Utilities.Results;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        string CreateFile(IFormFile file);
        void DeleteFile(string filePath);
        string UpdateFile(IFormFile file, string filePath);
    }
}