using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Core.Abstraction;
using Dapper.Core.Models;
using Dapper.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Dapper.EF.Core
{
    public class NetworkEventsContext : DbContext, INetworkEventsService
    {
        private DatabaseSettings DbSettings { get; }
        private readonly string _connectionString;

        public NetworkEventsContext(IOptions<DatabaseSettings> dbOptions)
        {
            DbSettings = dbOptions.Value;
            _connectionString = DbSettings.ConnectionString;
        }

        public NetworkEventsContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public DbSet<NetworkEvent> NetworkEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


        public async Task<IEnumerable<NetworkEvent>> GetAllEventsAsync()
        {
            return await NetworkEvents.ToListAsync();
        }

        public async Task<NetworkEvent> GetEventByIdAsync(int id)
        {
            return await NetworkEvents.SingleAsync(x => x.Id == id);
        }
    }
}