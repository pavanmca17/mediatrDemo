using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mediatrDemo.Controllers
{
   
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IDataService _dataService;

        public NotificationController(IDataService dataService)
        {
            _dataService = dataService; 
        }

        [HttpGet]
        [Route("api/[controller]/message")]
        public async Task<bool> SendMessage(string messageData, CancellationToken cancellationToken)
        {
            var messageDetails = new MessageDetails();
            messageDetails.createdBy = "TestUser";
            messageDetails.CreatedDate = DateTime.Now;
            messageDetails.messageData = messageData;
            return await _dataService.SendMessage(messageDetails, cancellationToken);
           
        }

        [HttpGet]
        [Route("api/[controller]/request")]
        public async Task<Response> SendRequest(string payload, CancellationToken cancellationToken)
        {
            return await _dataService.SendRequest(payload, cancellationToken);          
        }

    }
}
