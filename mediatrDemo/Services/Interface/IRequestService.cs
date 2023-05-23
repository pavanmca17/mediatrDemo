using mediatrDemo.Model;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo.Services.Interface
{
    public interface IRequestService
    {
        Task<Response> SendRequest(string payload, CancellationToken cancellationToken);
    }
}
