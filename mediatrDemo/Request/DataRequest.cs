using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class DataRequest : IRequest<string>
    {
        public String data { get; set; }

    }
}
