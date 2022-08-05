using mediatrDemo.Model;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo.Services.Interface
{
    public interface IDataService
    {
        Task<bool> SendMessage(MessageDetailsDTO messageDetails, CancellationToken cancellationToken);
        Task<Response> SendRequest(string payload, CancellationToken cancellationToken);
    }
}
