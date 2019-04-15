using Application.UseCases.GetClientOrders;
using Application.UseCases.SearchCustomerByName;
using AutoMapper;
using Infrastructure.Database.Repo.Customer;
using Infrastructure.Database.Repo.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUi.Models;
using WebUi.Services.Orders;

namespace WebUi.Shared
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<ClientOrderRepoResponseModel, ClientOrderApplicationResponseModel>();

            CreateMap<ClientOrderApplicationResponseModel, ClientOrderServiceResponseModel>();

            CreateMap<OrderRepoResponse, OrderRepoResponse>();

            CreateMap<CustomerSearchRepoResponseModel, CustomerSearchApplicationResponseModel>();

            CreateMap<CustomerSearchApplicationResponseModel, CustomerSearchMvcResponseModel>();

        }


    }
}
