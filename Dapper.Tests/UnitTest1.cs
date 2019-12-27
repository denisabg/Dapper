using System.Threading.Tasks;
using Dapper.Core.Abstraction;
using Dapper.Core.Repository.Services;
using Dapper.EF.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static string ConnectionString { get; } =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PortnoxDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [TestMethod]
        public async Task DapperUnitTest()
        {
            INetworkEventsService repository = new NetworkEventsService(ConnectionString);

            var resAll = await repository.GetAllEventsAsync();
            Assert.IsNotNull(resAll);

            const int id = 3;
            var res = await repository.GetEventByIdAsync(id);

            Assert.IsNotNull(res);
        }


        [TestMethod]
        public async Task EfCoreUnitTest()
        {
            INetworkEventsService repository = new NetworkEventsContext(ConnectionString);

            var resAll = await repository.GetAllEventsAsync();

            Assert.IsNotNull(resAll);


            const int id = 3;
            var res = await repository.GetEventByIdAsync(id);

            Assert.IsNotNull(res);
        }
    }
}