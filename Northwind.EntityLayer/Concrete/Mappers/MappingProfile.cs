using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;

namespace Northwind.EntityLayer.Concrete.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, DtoCustomer>().ReverseMap();
            CreateMap<Order, DtoOrder>().ReverseMap();
        }
    }
}
