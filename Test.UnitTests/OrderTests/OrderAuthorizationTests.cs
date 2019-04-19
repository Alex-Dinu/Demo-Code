using System;
using System.Collections.Generic;
using System.Text;
using Application.Shared;
using Application.Shared.Exceptions;
using Application.UseCases.GetOrder;
using Moq;
using Newtonsoft.Json;
using Xunit;


namespace Test.UnitTests.OrderTests
{
    public class OrderAuthorizationTests : TestsBase
    {
        IClientOrderAuthorization _clientOrderAuthorization;
        public OrderAuthorizationTests(IClientOrderAuthorization clientOrderAuthorization)
        {
            _clientOrderAuthorization = clientOrderAuthorization;
        }
        [Fact]
        public void When_Client_Has_No_Authorization_To_View_Order_Raise_Exception()
        {
            OrderApplicationResponseModel OrderApplicationResponseData = new OrderApplicationResponseModel
            {
                CustomerID = 1
            };

            Assert.Throws<ClientOrderAuthorizationException>(() =>
                _clientOrderAuthorization.AuthorizeClientToViewOrder(2, OrderApplicationResponseData));


       }



    }
}
