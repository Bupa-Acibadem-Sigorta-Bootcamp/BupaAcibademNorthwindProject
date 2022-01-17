using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Northwind.EntityLayer.Concrete.Mappers;

namespace Northwind.BusinessLogicLayer.Concrete.MapperConfiguration
{
    internal class ObjectMapper
    {
        //TODO : Lazy metodu proje içersinde ihtiyaç halinde çalışan yapıdır.
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new AutoMapper.MapperConfiguration(configuration =>
            {
                configuration.AddProfile<MappingProfile>();
            });
            return configuration.CreateMapper();
        });

        public static readonly IMapper Mapper = lazy.Value;
    }
}
