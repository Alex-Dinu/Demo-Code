using AutoMapper;
using Infrastructure.Database.Repo.Orders;
using Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.GetClientOrders
{
    public interface IClientOrder
    {
        Task<List<ClientOrderApplicationResponseModel>> GetClientOrders(int clientId);
    }


    public class ClientOrder: IClientOrder
    {
        IClientOrders _clientOrders;
        IDataLogger _dataLogger;
        IMapper _mapper;

        public ClientOrder(IClientOrders clientOrders
            , IDataLogger dataLogger
            , IMapper mapper)
        {
            _clientOrders = clientOrders;
            _dataLogger = dataLogger;
            _mapper = mapper;
        }

        public async Task<List<ClientOrderApplicationResponseModel>> GetClientOrders(int clientId)
        {
            _dataLogger.LogInformation("Application.UseCases.GetClientOrders.GetClientOrders(clientId)", clientId);

            var repoClientOrders = await _clientOrders.GetClientOrders(clientId);

            return  _mapper.Map<List<ClientOrderApplicationResponseModel>>(repoClientOrders);
        }
    }
}
