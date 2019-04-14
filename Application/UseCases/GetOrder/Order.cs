using Application.Shared;
using AutoMapper;
using Infrastructure.Database.Repo.Orders;
using Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.GetOrder
{
    public interface IOrder
    {
        Task<OrderApplicationResponseModel> GetOrder(int clientId, int orderId);
    }
    public class Order : IOrder
    {
        IOrderRepo _orderRepo;
        IDataLogger _dataLogger;
        IMapper _mapper;
        IClientOrderAuthorization _clientOrderAuthorization;

        public Order(IOrderRepo orderRepo
            , IDataLogger dataLogger
            , IMapper mapper
            , IClientOrderAuthorization clientOrderAuthorization)
        {
            _orderRepo = orderRepo;
            _dataLogger = dataLogger;
            _mapper = mapper;
            _clientOrderAuthorization = clientOrderAuthorization;
        }

        public async Task<OrderApplicationResponseModel> GetOrder(int clientId, int orderId)
        {
            _dataLogger.LogInformation("Application.UseCases.Order.GetOrder(clientId, orderId)", clientId, orderId);

            var order = await _orderRepo.GetOrder(orderId);


            _clientOrderAuthorization.AuthorizeClientToViewOrder(clientId, _mapper.Map<OrderApplicationResponseModel>(order));

            return _mapper.Map<OrderApplicationResponseModel>(order);
        }
    }

}
