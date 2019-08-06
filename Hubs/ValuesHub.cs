using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace coreWithSignalR.Hubs
{
    public class ValuesHub: Hub<IValuesClient>
    {
        public async Task Add(string value) => await Clients.All.Add(value);

        public async Task Delete(string value) => await Clients.All.Delete(value);
    }
}
