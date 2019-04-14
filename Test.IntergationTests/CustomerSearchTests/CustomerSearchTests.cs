using Application.UseCases.SearchCustomerByName;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.IntegrationTests;
using Xunit;

namespace Test.IntergationTests.CustomerSearchTests
{
    public class CustomerSearchTests: TestsBase
    {
        ICustomerSearch _customerSearch;
        public CustomerSearchTests(ICustomerSearch customerSearch)
        {
            _customerSearch = customerSearch;
        }
        [Fact]

        public async Task Customner_Search_By_Valid_Name_Will_Return_At_Least_One_Result()
        {
            var customers = await _customerSearch.GetCustomersByName("a");

            Assert.True(customers.)
        }
    }
}
