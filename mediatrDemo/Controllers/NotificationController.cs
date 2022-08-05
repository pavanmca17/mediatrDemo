using System;
using System.Threading;
using System.Threading.Tasks;
using mediatrDemo.Model;
using mediatrDemo.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace mediatrDemo.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(IDataService dataService, ILogger<NotificationController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        [HttpPost]
        [Route("/message")]
        public async Task<bool> SendMessage(MessageDetailsDTO messagedetails, CancellationToken cancellationToken)
        {
            _logger.LogInformation("NotificationController -> SendMessage");                      
            return await _dataService.SendMessage(messagedetails, cancellationToken);
           
        }

        [HttpGet]
        [Route("/request")]
        public async Task<Response> SendRequest(string payload, CancellationToken cancellationToken)
        {
            _logger.LogInformation(payload);
            return await _dataService.SendRequest(payload, cancellationToken);          
        }

    }
}
