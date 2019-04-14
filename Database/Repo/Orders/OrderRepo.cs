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
    public interface IOrderRepo
    {
        Task<OrderRepoResponse> GetOrder(int orderId);
    }
    public class OrderRepo : IOrderRepo
    {
        private WideWorldImportersContext _context;
        private IDataLogger _dataLogger;
        public OrderRepo(WideWorldImportersContext context, IDataLogger dataLogger)
        {
            _context = context;
            _dataLogger = dataLogger;
        }
        public async Task<OrderRepoResponse> GetOrder(int orderId)
        {
            validateOrderId(orderId);
            _dataLogger.LogInformation("Input data", orderId);
            try
            {
                return await GetOrderData(orderId);
            }
            catch (Exception ex)
            {
                _dataLogger.LogError(ex);
                throw;

            }

        }

        private void validateOrderId(int orderId)
        {
            if (orderId == 0)
                throw new NullInputParameterException("orderId is invalid.");
        }

        private async Task<OrderRepoResponse> GetOrderData(int orderId)
        {
            _dataLogger.LogInformation("exec [Application].[GetOrder] " + orderId, orderId);

            var order = _context.Order
                .FromSql("[Application].[GetOrder] @p0", orderId)
                .FirstOrDefaultAsync();
            return await order;
        }
    }

}
