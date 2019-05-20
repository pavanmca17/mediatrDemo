using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public class DataRequestHandler : IRequestHandler<DataRequest, string>
    {
        public Task<string> Handle(DataRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult<string>(request.data);
        }       
    }
}
