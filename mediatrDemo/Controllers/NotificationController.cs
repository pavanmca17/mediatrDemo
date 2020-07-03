﻿using System.Threading;
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
        public async Task<bool> SendMessage(MessageDetails messageDetails, CancellationToken cancellationToken)
        {
            return await _dataService.SendMessage(messageDetails, cancellationToken);
           
        }

        [HttpGet]
        [Route("api/[controller]/request")]
        public async Task<bool> SendRequest(string payload, CancellationToken cancellationToken)
        {
            return await _dataService.SendRequest(payload, cancellationToken);          
        }

    }
}
