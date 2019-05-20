using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mediatrDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediatorService _mediatorService;

        public NotificationController(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService; //
        }

        [HttpGet]
        public ActionResult<string> NotifyMessage()
        {
            _mediatorService.Notify("This is a test notification message");
            return "Notified";
        }

        [HttpGet]
        public async Task<string> SendMessage(String _data)
        {
            String data = await _mediatorService.Send(_data);
            return data;
        }

    }
}
