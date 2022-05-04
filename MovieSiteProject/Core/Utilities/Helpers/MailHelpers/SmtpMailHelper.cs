﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieSiteProject.Core.Utilities.IoC;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MovieSiteProject.Core.Utilities.Helpers.MailHelpers
{
    public class SmtpMailHelper : IMailHelper
    {
        public SmtpMailHelper()
        {
            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        }

        public IConfiguration Configuration { get; }

        public void Send(string to, string message, string subject, bool isBodyHtml = false)
        {
            SmtpMailConfiguration smtpConfiguration = Configuration.GetSection("SmtpMailConfiguration").Get<SmtpMailConfiguration>();

            MailMessage mailMessage = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            mailMessage.From = new MailAddress(smtpConfiguration.Email, smtpConfiguration.DisplayName, Encoding.UTF8);
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.Body = message;

            smtp.Host = smtpConfiguration.Host;
            smtp.Port = smtpConfiguration.Port;
            smtp.EnableSsl = smtpConfiguration.EnableSsl;
            smtp.UseDefaultCredentials = smtpConfiguration.UseDefaultCredentials;
            smtp.Credentials = new NetworkCredential(smtpConfiguration.Email, smtpConfiguration.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mailMessage);
        }
    }

    public class SmtpMailConfiguration
    {
        public string Email { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
    }
}