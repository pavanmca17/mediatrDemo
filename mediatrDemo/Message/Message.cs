using MediatR;

namespace mediatrDemo
{
    public class Message : INotification
    {
        public MessageDetails messageDetails { get; set; }
       
    }
}
