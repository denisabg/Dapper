using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Core.Abstraction;
using Dapper.Core.Models;
using Microsoft.Extensions.Options;

namespace Dapper.Core.Repository.Services
{
    public class NetworkEventsService : INetworkEventsService
    {
        private DatabaseSettings DbSettings { get; }
        private readonly string _connectionString;

        public NetworkEventsService(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public NetworkEventsService(IOptions<DatabaseSettings> dbOptions)
        {
            this.DbSettings = dbOptions.Value;
            this._connectionString = this.DbSettings.ConnectionString;
        }



        public async Task<IEnumerable<NetworkEvent>> GetAllEventsAsync()
        {
            await using var connection = new SqlConnection(_connectionString);

            var result =
                await connection
                    .QueryAsync<NetworkEvent>("SELECT * FROM NetworkEvents");
            return
                result;
        }


        public async Task<NetworkEvent> GetEventByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            var result =
                await connection
                    .QueryAsync<NetworkEvent>(
                        "SELECT * FROM NetworkEvents Where Id=@Id",
                        new { Id = id });

            return
                result
                    .FirstOrDefault(x => x.Id == id);
        }
    }
}
