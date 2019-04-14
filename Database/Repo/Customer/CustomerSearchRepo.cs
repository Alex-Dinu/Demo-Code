using Infrastructure.Database.Context;
using Infrastructure.Log;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repo.Customer
{
    public interface ICustomerSearchRepo
    {
        Task<List<CustomerSearchRepoResponseModel>> SearchCustomers(string name);
    }
    public class CustomerSearchRepo: ICustomerSearchRepo
    {
        private WideWorldImportersContext _context;
        private IDataLogger _dataLogger;
        public CustomerSearchRepo(WideWorldImportersContext context, IDataLogger dataLogger)
        {
            _context = context;
            _dataLogger = dataLogger;
        }

        public async Task<List<CustomerSearchRepoResponseModel>> SearchCustomers(string name)
        {
            try
            {
                return await GetCustomers(name);
            }
            catch (Exception ex)
            {
                _dataLogger.LogError(ex);
                throw;

            }
        }

        private async Task<List<CustomerSearchRepoResponseModel>> GetCustomers(string name)
        {
            _dataLogger.LogInformation("exec [Application].[CustomerSearch] " + name, name);

            var customers = _context.CustomerSearch
                .FromSql("[Application].[CustomerSearch] @p0", name)
                .ToListAsync();
            return await customers;
        }
    }
}
