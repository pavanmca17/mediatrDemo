using mediatrDemo.Model;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo.Services.Interface
{
    public interface INotifcationService
    {   
        Task<string> SendNotification(Message message, CancellationToken cancellationToken);     
    }
}
