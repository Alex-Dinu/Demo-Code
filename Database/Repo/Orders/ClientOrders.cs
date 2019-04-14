using Infrastructure.Database.Context;
using Infrastructure.Database.Shared.Exceptions;
using Infrastructure.Log;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repo.Orders
{
    public interface IClientOrders
    {
        Task<List<ClientOrderRepoResponseModel>> GetClientOrders(int clientId);
    }
    public class ClientOrders : IClientOrders
    {
        private WideWorldImportersContext _context;
        private IDataLogger _dataLogger;
        public ClientOrders(WideWorldImportersContext context, IDataLogger dataLogger)
        {
            _context = context;
            _dataLogger = dataLogger;
        }
        public async Task<List<ClientOrderRepoResponseModel>> GetClientOrders(int clientId)
        {
            validateGetClientOrders(clientId);
            _dataLogger.LogInformation("Input data", clientId);
            try
            {
                return await GetClientOrdersSqlResults(clientId);
            }
            catch (Exception ex)
            {
                _dataLogger.LogError(ex);
                throw;

            }

        }

        private void validateGetClientOrders(int clientId)
        {
            if (clientId == 0)
                throw new NullInputParameterException("clientId is invalid.");
        }

        private async Task<List<ClientOrderRepoResponseModel>> GetClientOrdersSqlResults(int clientId)
        {
            _dataLogger.LogInformation("exec [Application].[GetCustomerOrderDetails] " + clientId, clientId);

            var clientOrders = _context.ClientOrders
                .FromSql("[Application].[GetCustomerOrderDetails] @p0", clientId)
                .ToListAsync();
            return await clientOrders;
        }
    }
}
