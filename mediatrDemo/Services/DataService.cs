using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class DataService : IDataService
    {
        private readonly IMediator _mediator;

        public DataService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> SendMessage(MessageDetails messageDetails, CancellationToken cancellationToken)
        {
            var message = new Message { messageDetails = messageDetails };
            await _mediator.Publish<Message>(message, cancellationToken);
            return true;
        }
      
        public async Task<bool> SendRequest(string payload, CancellationToken cancellationToken)
        {
            var request = new Request() { data = payload };
            var response = await _mediator.Send<Dto>(request, cancellationToken);
            return response.isSucess;
          
        }

        
    }
}
