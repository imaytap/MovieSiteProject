namespace MovieSiteProject.Core.Utilities.Helpers.FileHelpers
{
    public class RootFileHelper : IFileHelper
    {
        private readonly string folder = "\\assets\\";
        private readonly string path = Directory.GetCurrentDirectory() + "\\wwwroot";

        public RootFileHelper()
        {
        }

        public string CreateFile(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var guid = Guid.NewGuid().ToString() + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;

            var imagePath = folder + guid + extension;
            while (File.Exists(path + imagePath))
            {
                guid = Guid.NewGuid().ToString() + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                imagePath = folder + guid + extension;
            }

            using (var fileStream = File.Create(path + imagePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                imagePath = imagePath.Replace("\\", "/");

                return imagePath;
            }
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(path + filePath))
                File.Delete(path + filePath);
        }

        public string UpdateFile(IFormFile file, string filePath)
        {
            DeleteFile(filePath);
            return CreateFile(file);
        }
    }
}