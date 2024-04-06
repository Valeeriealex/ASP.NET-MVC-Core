using System.Net.Mail;

namespace ASP.NET_MVC_Core
{
    //интерфейс для шлюза обмена сообщениями
    public interface IMessagingGateway
    {
        Task SendMessageAsync(Message message);
    }
}
