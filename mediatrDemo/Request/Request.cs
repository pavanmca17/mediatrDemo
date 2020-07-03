using MediatR;

namespace mediatrDemo
{
    public class Request : IRequest<Dto>
    {
        public string data { get; set; }

        public bool isSucess { get; set; }

    }
}
