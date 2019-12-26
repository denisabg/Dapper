using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Proxy.Models;

namespace Dapper.Proxy.Abstraction
{
    public interface INetworkEventsService
    {
        Task<IEnumerable<NetworkEvent>> GetAllEventsAsync();
        Task<NetworkEvent> GetEventByIdAsync(int id);


    }
}