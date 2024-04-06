using System.Net.Mail;

namespace ASP.NET_MVC_Core
{   //служба сообщений
    public class MessageService
    {
        private readonly IMessagingGateway _messagingGateway;

        public MessageService(IMessagingGateway messagingGateway)
        {
            _messagingGateway = messagingGateway;
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            await _messagingGateway.SendMessageAsync(emailMessage);
        }
    }
}
