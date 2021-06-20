using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class RequestHandler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
           return Task.FromResult(new Response() { data= $"Response generated-DateTime{DateTime.Now.ToString()}", isSucess = true }); 
        }       
    }
}
