using MediatR;

namespace mediatrDemo
{
    public class Request : IRequest<Response>
    { 
        public string data { get; set; }

    }
}
