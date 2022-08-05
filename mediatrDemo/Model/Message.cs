using MediatR;

namespace mediatrDemo.Model
{
    public class Message : INotification
    {
        public MessagePayload MessagePayload { get; set; }
       
    }
}
