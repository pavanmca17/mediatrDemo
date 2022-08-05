using MediatR;
using System.Threading;
using System.Threading.Tasks;
using mediatrDemo.Model;
using Microsoft.Extensions.Logging;

namespace mediatrDemo
{
    public class DataMessageNotificationHandler : INotificationHandler<Message>
    {
        private readonly ILogger<DataMessageNotificationHandler> _logger;
        public DataMessageNotificationHandler(ILogger<DataMessageNotificationHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(Message request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(DataMessageNotificationHandler)}  : {request.MessagePayload.messageData} ");
            Task.Delay(1000);          
            return Task.CompletedTask;
        }

    }

   
}
