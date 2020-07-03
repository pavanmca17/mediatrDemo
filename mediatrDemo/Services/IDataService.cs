using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public interface IDataService
    {
        Task<bool> SendMessage(MessageDetails messageDetails, CancellationToken cancellationToken);
        Task<bool> SendRequest(string payload, CancellationToken cancellationToken);
    }
}
