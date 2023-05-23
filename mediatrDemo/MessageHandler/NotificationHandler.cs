using MediatR;
using System.Threading;
using System.Threading.Tasks;
using mediatrDemo.Model;
using Microsoft.Extensions.Logging;

namespace mediatrDemo
{
    public class NotificationHandler : INotificationHandler<NotifictionMessage>
    {
        private readonly ILogger<NotificationHandler> _logger;
        public NotificationHandler(ILogger<NotificationHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotifictionMessage notifictionMessage, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"RequestId:{notifictionMessage.Guid}");
            _logger.LogInformation($"{nameof(NotificationHandler)}  : {notifictionMessage.Message} ");
            Task.Delay(1000);          
            return Task.CompletedTask;
        }

    }

   
}
