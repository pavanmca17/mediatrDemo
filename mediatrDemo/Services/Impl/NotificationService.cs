using MediatR;
using mediatrDemo.Model;
using mediatrDemo.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo.Services.Impl
{
    public class NotificationService : INotifcationService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(IMediator mediator, ILogger<NotificationService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<string> SendNotification(Message message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DataService -> SendMessage");

            string notificationID = Guid.NewGuid().ToString();
            var notifictionMessage = new NotifictionMessage{
                                         Guid = notificationID,
                                         Message= message
            };

            await _mediator.Publish(notifictionMessage, cancellationToken);
            return notificationID;
        }

       

    }
}
