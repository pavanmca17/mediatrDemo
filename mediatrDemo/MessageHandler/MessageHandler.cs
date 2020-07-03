using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class MessageHandler : INotificationHandler<Message>
    {
        public Task Handle(Message request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from MessageHandler  : {request.messageDetails.messageData} ");
            Task.Delay(1000);
            Task.Delay(1000);
            return Task.CompletedTask;
        }
        
    }

   
}
