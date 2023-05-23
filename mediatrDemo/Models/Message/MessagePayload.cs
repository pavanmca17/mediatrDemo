using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mediatrDemo.Model
{
    public class MessagePayload
    {
        public string messageData { get; set; }

        public DateTime CreatedDate { get; set; }

        public string createdBy { get; set; }

    }
}
