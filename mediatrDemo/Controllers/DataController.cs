using System.Threading;
using System.Threading.Tasks;
using mediatrDemo.Model;
using mediatrDemo.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace mediatrDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly INotifcationService _notifcationService;
        private readonly ILogger<DataController> _logger;

        public DataController(IRequestService requestService,INotifcationService notifcationService, ILogger<DataController> logger)
        {
            _requestService = requestService;
            _notifcationService = notifcationService;
            _logger = logger;
        }

        [HttpPost]
        [Route("/notify")]
        public async Task<string> SendNotifcation(Message messageViewModel, CancellationToken cancellationToken)
        {            
            _logger.LogInformation($"{nameof(DataController)} -> {nameof(SendNotifcation)}");                      
            return await _notifcationService.SendNotification(messageViewModel, cancellationToken);           
        }

        [HttpGet]
        [Route("/request")]
        public async Task<Response> SendRequest(string requestID, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(DataController)} -> {nameof(SendRequest)}");
            return await _requestService.SendRequest(requestID, cancellationToken);          
        }

    }
}
