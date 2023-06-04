using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class RequestHandler : IRequestHandler<Request, Response>
    {
        private readonly ILogger<RequestHandler> _logger;
        public RequestHandler(ILogger<RequestHandler> logger)
        {
            _logger = logger;
        }
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"RequestHandler{nameof(RequestHandler)} -> Handle{Handle}");           
            return Task.FromResult(new Response() { responseGeneratedDateTime = DateTime.Now.ToString(), isSucess = true }); 
        }       
    }
}
