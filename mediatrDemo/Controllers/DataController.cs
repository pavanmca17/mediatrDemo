using System.Threading;
using System.Threading.Tasks;
using mediatrDemo.Model;
using mediatrDemo.Services.Impl;
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
        public async Task<string> SendNotifcation(Message message, CancellationToken cancellationToken)
        {
            
            _logger.LogInformation("DataController -> SendNotifcation");                      
            return await _notifcationService.SendNotification(message, cancellationToken);
           
        }

        [HttpGet]
        [Route("/request")]
        public async Task<Response> SendRequest(string requestID, CancellationToken cancellationToken)
        {
           
            return await _requestService.SendRequest(requestID, cancellationToken);          
        }

    }
}
