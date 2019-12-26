using System.Threading.Tasks;
using Dapper.Proxy.Abstraction;
using Dapper.Proxy.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const string ConnectionString = 
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PortnoxDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [TestMethod]
        public async Task TestMethod1()
        {
        
            INetworkEventsService repository = new NetworkEventsService(ConnectionString);

            var res = await repository.GetAllEventsAsync();

            Assert.IsNotNull(res);

        }



    }
}
