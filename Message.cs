namespace ASP.NET_MVC_Core
{   //абстрактный класс для сообщения
    public abstract class Message
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
