using Application.Shared.Exceptions;
using Application.UseCases.GetOrder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared
{
    public interface IClientOrderAuthorization
    {
        void AuthorizeClientToViewOrder(int clientId, OrderApplicationResponseModel order);
    }

    public class ClientOrderAuthorization : IClientOrderAuthorization
    {
        public void AuthorizeClientToViewOrder(int clientId, OrderApplicationResponseModel order)
        {
            if (order.CustomerID != clientId)
                throw new ClientOrderAuthorizationException("You have no access to the order.");
        }
    }
}
