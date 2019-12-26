using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Core.Models;

namespace Dapper.Core.Abstraction
{
    public interface INetworkEventsService
    {
        Task<IEnumerable<NetworkEvent>> GetAllEventsAsync();
        Task<NetworkEvent> GetEventByIdAsync(int id);


    }
}