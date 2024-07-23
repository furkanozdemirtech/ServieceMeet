using CreatedMeetRepository.SqlContext;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace CreaterMeetService.MailHelper
{
    public class EmailService
    {
        private readonly MeetDbContext _context;
        public EmailService(MeetDbContext context)
        {
            _context = context;
        }
        public async Task SendEmailBasedOnSetting()
        {
            var setting = await _context.MEETs
                                        .FirstOrDefaultAsync(s => s.START_TIME == DateTime.Now.AddDays(-1));

            if (setting != null)
            {
                await SendEmail();
            }
        }
        public async Task SendEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Furkan Özdemir", "furkanozdemirtrakya@gmail.com"));
            message.To.Add(new MailboxAddress("Sayın", "furkanozdemirtech@gmail.com"));
            message.Subject = "";

            message.Body = new TextPart("plain")
            {
                Text = "."
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync("smtp.furkanozdemirtrakya@gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

                await client.AuthenticateAsync("furkanozdemirtech@gmail.com", "680392Aaader3#");

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}