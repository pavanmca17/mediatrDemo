using MediatR;

namespace mediatrDemo.Model
{
    public class NotifictionMessage : INotification
    {
        public string Guid { get; set; }
        public Message Message { get; set; }
       
    }
}
