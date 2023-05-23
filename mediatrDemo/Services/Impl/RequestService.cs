using MediatR;
using mediatrDemo.Model;
using mediatrDemo.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo.Services.Impl
{
    public class RequestService : IRequestService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RequestHandler> _logger;

        public RequestService(IMediator mediator, ILogger<RequestHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
   
        public async Task<Response> SendRequest(string payload, CancellationToken cancellationToken)
        {
            _logger.LogInformation("RequestService->IRequestService");
            var request = new Request() { data = payload };
            return await _mediator.Send(request, cancellationToken);

        }


    }
}
