using MediatR;
using mediatrDemo.Model;
using mediatrDemo.Services.Interface;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo.Services.Impl
{
    public class DataService : IDataService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DataService> _logger;

        public DataService(IMediator mediator, ILogger<DataService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<bool> SendMessage(MessageDetailsDTO messageDetails, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DataService -> SendMessage");
            var message = new Message { MessagePayload = messageDetails };
            await _mediator.Publish(message, cancellationToken);
            return true;
        }

        public async Task<Response> SendRequest(string payload, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DataService -> SendRequest");
            var request = new Request() { data = payload };
            return await _mediator.Send(request, cancellationToken);

        }


    }
}
