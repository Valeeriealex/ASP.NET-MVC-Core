using System.Net.Mail;
using System.Net;

namespace ASP.NET_MVC_Core
{   //шлюз электронной почты с использованием SMTP
    public class EmailGateway : IMessagingGateway
    {
        private readonly SmtpClient _smtpClient;
        private readonly NetworkCredential _credentials;

        public EmailGateway(string host, int port, string username, string password)
        {
            _smtpClient = new SmtpClient(host, port);
            _credentials = new NetworkCredential(username, password);
        }

        public async Task SendMessageAsync(Message message)
        {
            var emailMessage = new MailMessage(_credentials.UserName, message.Recipient)
            {
                Subject = message.Subject,
                Body = message.Content
            };

            _smtpClient.Credentials = _credentials;
            await _smtpClient.SendMailAsync(emailMessage);
        }
    }
}
