using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class RequestHandler : IRequestHandler<Request, Dto>
    {
        public Task<Dto> Handle(Request request, CancellationToken cancellationToken)
        {
            // do something with the request data 
            // return the response
            return Task.FromResult(new Dto() { isSucess = true }); 
        }       
    }
}
