namespace MovieSiteProject.Core.Utilities.Helpers.MailHelpers
{
    public interface IMailHelper
    {
        void Send(string to, string message, string subject, bool isBodyHtml = false);
    }
}