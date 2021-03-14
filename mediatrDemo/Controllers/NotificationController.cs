using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace mediatrDemo.Controllers
{
   
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(IDataService dataService, ILogger<NotificationController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/[controller]/message")]
        public async Task<bool> SendMessage(string messageData, CancellationToken cancellationToken)
        {
            var messageDetails = new MessageDetails();
            messageDetails.createdBy = "TestUser";
            messageDetails.CreatedDate = DateTime.Now;
            messageDetails.messageData = messageData;
            _logger.LogInformation(JsonConvert.SerializeObject(messageDetails));
            return await _dataService.SendMessage(messageDetails, cancellationToken);
           
        }

        [HttpGet]
        [Route("api/[controller]/request")]
        public async Task<Response> SendRequest(string payload, CancellationToken cancellationToken)
        {
            _logger.LogInformation(payload);
            return await _dataService.SendRequest(payload, cancellationToken);          
        }

    }
}
