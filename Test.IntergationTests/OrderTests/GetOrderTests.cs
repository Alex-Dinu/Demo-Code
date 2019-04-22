using Application.Shared.Exceptions;
using Application.UseCases.GetOrder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.IntegrationTests;
using Test.IntergationTests.TextFixtures;
using Xunit;

namespace Test.IntergationTests.OrderTests
{
    [Collection("Test Data collection")]
    public class GetOrderTests : TestsBase
    {
        private TestClientFixture _testClientFixture;

        public GetOrderTests(TestClientFixture testClientFixture)
        {
            _testClientFixture = testClientFixture;

        }
        [Fact]
        public void t()
        {
            Assert.Equal(1, 1);
        }
        [Theory]
        [ClassData(typeof(UnauthorizedOrderAccess))]
        [ClassData(typeof(AuthorizedOrderAccess))]

        public async Task OrderAuthorizationTests(int clientId, int orderId, bool expectedResult)
        {
            bool actualResult = true;
                var response = await _testClientFixture.Client.GetAsync("v1/demo/orders/" + clientId + "/" + orderId);

                var responseStatus = response.StatusCode;

                if(responseStatus == System.Net.HttpStatusCode.Unauthorized)
                    actualResult = false;


            Assert.Equal(expectedResult, actualResult);

        }
    }

    public class UnauthorizedOrderAccess : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 7, 6564, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

    public class AuthorizedOrderAccess : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1009, 6564, true };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
