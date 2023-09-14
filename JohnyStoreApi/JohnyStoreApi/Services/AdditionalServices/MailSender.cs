using System.Net.Mail;
using System.Net;
using JohnyStoreApi.Services.Interfaces;

namespace JohnyStoreApi.Services.AdditionalServices
{
    public class MailSender : IMailSender
    {
        private readonly string _mail;
        private readonly string _password;
        private readonly string _smtpAddress;
        private int _smtpPort;

        public MailSender(IConfiguration configuration)
        {
            _mail = configuration.GetValue<string>("Mail:Login");
            _password = configuration.GetValue<string>("Mail:Password");
            _smtpAddress = configuration.GetValue<string>("Mail:SmtpAddress");
            _smtpPort = Convert.ToInt32(configuration.GetValue<string>("Mail:SmtpPort"));
        }

        public void SendMail(string email, string themeMail,  string message)
        {
            var smtpClient = new SmtpClient(_smtpAddress, _smtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_mail, _password);
            smtpClient.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_mail);
            mailMessage.To.Add(email);
            mailMessage.Subject = themeMail;
            mailMessage.Body = message;

            smtpClient.Send(mailMessage);
        }
    }
}
