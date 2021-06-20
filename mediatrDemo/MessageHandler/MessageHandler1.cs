using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class MessageHandler1 : INotificationHandler<Message>
    {
        public Task Handle(Message request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from {nameof(MessageHandler1)}  : {request.messageDetails.messageData} ");
            Task.Delay(1000);
            Task.Delay(1000);
            return Task.CompletedTask;
        }

    }
}
