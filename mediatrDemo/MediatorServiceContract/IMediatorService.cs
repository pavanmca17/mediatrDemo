using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mediatrDemo
{
    public interface IMediatorService
    {
        void Notify(string notifyText);
        Task<String> Send(String Data);
    }
}
