using MediatR;
using System.Threading;
using System.Threading.Tasks;
using mediatrDemo.Model;
using Microsoft.Extensions.Logging;

namespace mediatrDemo
{
    public class FileMessageNotificatioHandler : INotificationHandler<Message>
    {
        private readonly ILogger<FileMessageNotificatioHandler> _logger;

        public FileMessageNotificatioHandler(ILogger<FileMessageNotificatioHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(Message request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(FileMessageNotificatioHandler)}  : {request.MessagePayload.messageData} ");
            Task.Delay(1000);           
            return Task.CompletedTask;
        }

    }
}
