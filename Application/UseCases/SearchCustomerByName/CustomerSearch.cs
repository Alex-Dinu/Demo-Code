using AutoMapper;
using Infrastructure.Database.Repo.Customer;
using Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.SearchCustomerByName
{
    public interface ICustomerSearch
    {
        Task<List<CustomerSearchApplicationResponseModel>> GetCustomersByName(string name);
    }
    public class CustomerSearch: ICustomerSearch
    {
        ICustomerSearchRepo _customerSearchRepo;
        IDataLogger _dataLogger;
        IMapper _mapper;

        public CustomerSearch(ICustomerSearchRepo customerSearchRepo
            , IDataLogger dataLogger
            , IMapper mapper)
        {
            _customerSearchRepo = customerSearchRepo;
            _dataLogger = dataLogger;
            _mapper = mapper;
        }

        public async Task<List<CustomerSearchApplicationResponseModel>> GetCustomersByName(string name)
        {
            _dataLogger.LogInformation("Application.UseCases.SearchCustomerByName.GetCustomersByName(name)", name);

            var customers = await _customerSearchRepo.SearchCustomers(name);

            return _mapper.Map<List<CustomerSearchApplicationResponseModel>>(customers);

        }
    }
}
