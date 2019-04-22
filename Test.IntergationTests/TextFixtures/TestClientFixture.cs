using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Test.IntergationTests.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using WebUi;

namespace Test.IntergationTests.TextFixtures
{
    public class TestClientFixture : IDisposable
    {
        private TestServer _server;

        public HttpClient Client { get; private set; }

        public TestDataModel TestData { get; private set; }
        public string EnvironmentToTest { get; private set; }

        public TestClientFixture()
        {
            EnvironmentToTest = TestConfigurator.EnvironmentConfiguration;
            var config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{EnvironmentToTest}.json", optional: false)
                .AddJsonFile($"testData.{EnvironmentToTest}.json", optional: false)
                .Build();

            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseEnvironment(EnvironmentToTest)
                .UseConfiguration(config)
            );

            TestDataModel testData = new TestDataModel();
            config.Bind("TestData", testData);
            TestData = testData;



            Client = _server.CreateClient();

        }
        public void Dispose()
        {
            // ... clean up test data from the database ...
        }


    }

    [CollectionDefinition("Test Data collection")]
    public class TestDataCollection : ICollectionFixture<TestClientFixture>
    {
    }
}
