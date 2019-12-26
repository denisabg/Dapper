using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper.Api;
using Dapper.Proxy.Abstraction;
using Dapper.Proxy.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public async Task TestMethod1()
        {
        
            string basePath= System.AppContext.BaseDirectory;

            IConfiguration configuration= new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();




            DatabaseSettings dbSettings = new DatabaseSettings
            {
                ConnectionString =  configuration.GetSection("DatabaseSettings").Value
            };

            IOptions<DatabaseSettings> options = new OptionsWrapper<DatabaseSettings>(dbSettings);


            Assert.IsNotNull(options);

        }



    }
}
