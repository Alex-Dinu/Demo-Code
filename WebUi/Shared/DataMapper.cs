using Application.UseCases.GetClientOrders;
using AutoMapper;
using Infrastructure.Database.Repo.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUi.Services.Orders;

namespace WebUi.Shared
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<ClientOrderRepoResponseModel, ClientOrderApplicationResponseModel>();


            //CreateMap<Foo, Bar>().ForMember(x => x.Blarg, opt => opt.Ignore());


            //     Mapper.CreateMap<MoveEntity, MoveEntityDto>()
            //.ForMember(dest => dest.PrimaryOriginTransferee, opt => opt.Ignore())
            //.ForMember(dest => dest.PrimaryDestinationTransferee, opt => opt.Ignore())
            //.ForMember(dest => dest.Customer, opt => opt.Ignore())
            //.ForMember(dest => dest.DestinationAddress, opt => opt.Ignore())
            //.ForMember(dest => dest.OriginAddress, opt => opt.Ignore())
            //.ForMember(dest => dest.Order, opt => opt.Ignore())
            //.ForMember(dest => dest.Shipment, opt => opt.Ignore())
            //.ForMember(dest => dest.SourceSystemName, opt => op


            CreateMap<ClientOrderApplicationResponseModel, ClientOrderServiceResponseModel>();


        }


    }
}
