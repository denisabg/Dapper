using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Proxy.Abstraction;
using Dapper.Proxy.Models;
using Microsoft.Extensions.Options;

namespace Dapper.Proxy.Repository
{
    public class NetworkEventsRepository : INetworkEventsRepository
    {
        private readonly IDbConnection _connection;

        private DatabaseSettings DbSettings { get; }

        public NetworkEventsRepository(IOptions<DatabaseSettings> dbOptions)
        {
            this.DbSettings = dbOptions.Value;
            this._connection = new SqlConnection(this.DbSettings.ConnectionString);
        }



        public async Task<IEnumerable<NetworkEvent>> GetAllEventsAsync()
        {
            using IDbConnection conn = _connection;

            conn.Open();
            var result = await conn.QueryAsync<NetworkEvent>("SELECT * FROM NetworkEvents");
            return result;
        }

        public async Task<NetworkEvent> GetEventByIdAsync(int id)
        {
            using IDbConnection conn = _connection;
            conn.Open();

            var result = await conn.QueryAsync<NetworkEvent>(
                "SELECT * FROM NetworkEvents Where Id=@Id",
                new {Id = id});

            return result.FirstOrDefault(x=> x.Id == id);
        }
    }
}
