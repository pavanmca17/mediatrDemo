using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class DataRequestHandler : IRequestHandler<Request, Response>
    {
        private readonly ILogger<DataRequestHandler> _logger;

        public DataRequestHandler(ILogger<DataRequestHandler> logger)
        {
            _logger = logger;
        }
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DataRequestHandler -> Handle");           
            return Task.FromResult(new Response() {  isSucess = true }); 
        }       
    }
}
