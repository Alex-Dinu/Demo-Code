using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.IntergationTests.Shared
{
    public static class TestDataGetter
    {
        public static TestDataModel GetTestData()
        {
            string environmentToTest = TestConfigurator.EnvironmentConfiguration;
            var config = new ConfigurationBuilder()
                .AddJsonFile($"testData.{environmentToTest}.json", optional: false)
                .Build();

            TestDataModel testData = new TestDataModel();
            config.Bind("TestData", testData);
            return testData;
        }
    }
}
