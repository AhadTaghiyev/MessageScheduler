

using MessageScheduler.Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace MessageScheduler.Service.Services.Implementations
{
    public class MailService : ISender
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Send(string to, string content)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_configuration.GetSection("Keys")["Email"], "message app");
            mail.To.Add(new MailAddress(to));
            mail.Subject = "remind";
            mail.Body = content;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(_configuration.GetSection("Keys")["Email"],_configuration.GetSection("Keys")["Secret"]);
            smtp.Send(mail);
        }
    }
}
