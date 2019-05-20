using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class NotificationMessageHandler : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from NotificationHandler Message  : {notification.NotifyText} ");
            Task.Delay(1000);
            Task.Delay(1000);
            return Task.CompletedTask;
        }
        
    }

   
}
