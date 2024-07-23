using CreatedMeetTools.Interface;
using System.Net;
using System.Net.Mail;

namespace CreatedMeetTools.Services
{
    public class SmptpEmailService : IEmailService
    {
        private string _smtpServer;
        private int _smpPort;
        private string _smtpUsername;
        private string _smtPassword;
        public SmptpEmailService(string smtpServer, int smtpPort, string smtUsername, string smtpPassword)
        {
            _smpPort = smtpPort;
            _smtpUsername = smtUsername;
            _smtPassword = smtpPassword;
            _smtpServer = smtpServer;

        }
        public bool SendEmail(string to, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress(_smtpUsername);
                var toAddress = new MailAddress(to);
                var smtp = new SmtpClient
                {
                    Host = _smtpServer,
                    Port = _smpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_smtpUsername, _smtPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
                return true;

            }
            catch (Exception ex)
            {

                string message = $"Mail gönderimi başarısız oldu: {ex.Message}";
                return false; ;
            }
        }
    }
}
