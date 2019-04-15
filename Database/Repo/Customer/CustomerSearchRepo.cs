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

        //private async Task<List<CustomerSearchRepoResponseModel>> GetCustomers(string name)
        //{
        //    _dataLogger.LogInformation("exec [Application].[CustomerSearch] " + name, name);

        //    var customers = _context.CustomerSearch
        //        .FromSql("[Application].[CustomerSearch] @p0", name)
        //        .ToListAsync();
        //    return await customers;
        //}

        private async Task<List<CustomerSearchRepoResponseModel>> GetCustomers(string name)
        {
            return new List<CustomerSearchRepoResponseModel>()
            {
                new CustomerSearchRepoResponseModel()
                {
                    CityName = "CityA",
                    CustomerID = 1,
                    CustomerName = "CustNameA",
                    FaxNumber = "111.222.3333",
                    FullName = "FullName A",
                    LogonName = "LogonA",
                    PhoneNumber = "222.333.4444",
                    PreferredName = "PreNameA",
                    EmailAddress = "A@here.com",
                    HireDate = new DateTime(2011, 06, 09)
                },
                new CustomerSearchRepoResponseModel()
                {
                    CityName = "CityB",
                    CustomerID = 2,
                    CustomerName = "CustNameB",
                    FaxNumber = "111.222.6666",
                    FullName = "FullName B",
                    LogonName = "LogonB",
                    PhoneNumber = "222.333.6666",
                    PreferredName = "PreNameB",
                    EmailAddress = "B@here.com",
                    HireDate = new DateTime(2015, 07, 25)
                },
                new CustomerSearchRepoResponseModel()
                {
                    CityName = "CityC",
                    CustomerID = 3,
                    CustomerName = "CustNameC",
                    FaxNumber = "111.222.7777",
                    FullName = "FullName C",
                    LogonName = "LogonC",
                    PhoneNumber = "222.333.7777",
                    PreferredName = "PreNameC",
                    EmailAddress = "C@here.com",
                    HireDate = new DateTime(1999, 12, 12)
                },
                new CustomerSearchRepoResponseModel()
                {
                    CityName = "CityD",
                    CustomerID = 4,
                    CustomerName = "CustNameD",
                    FaxNumber = "111.222.8888",
                    FullName = "FullName D",
                    LogonName = "LogonD",
                    PhoneNumber = "222.333.8888",
                    PreferredName = "PreNameD",
                    EmailAddress = "D@here.com",
                    HireDate = new DateTime(2018, 01, 02)
                }

            };
        }
    }
}
