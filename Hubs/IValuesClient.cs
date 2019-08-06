using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreWithSignalR.Hubs
{
    public interface IValuesClient
    {
        Task Add(string value);

        Task Delete(string value);
    }
}
