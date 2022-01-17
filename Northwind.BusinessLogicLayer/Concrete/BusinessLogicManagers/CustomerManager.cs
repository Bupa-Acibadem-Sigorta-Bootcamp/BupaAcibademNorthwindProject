using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.BusinessLogicLayer.Concrete.MapperConfiguration;
using Northwind.DataAccessLayer.Abstract.IRepository;
using Northwind.EntityLayer.Abstract.IBases;
using Northwind.EntityLayer.Concrete.Bases;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class CustomerManager : BusinessLogicBase<Customer, DtoCustomer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(IServiceProvider service, ICustomerRepository customerRepository) : base(service)
        {
            _customerRepository = customerRepository;
        }

        public IResponseBase<DtoCustomer> GetByStringId(string id)
        {
            try
            {
                return new ResponseBase<DtoCustomer>
                {
                    Data = ObjectMapper.Mapper.Map<Customer, DtoCustomer>(_customerRepository.GetByStringId(id)),
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    SuccessMessage = "Başarılı, veriler listelendi."
                };
            }
            catch (Exception e)
            {
                return new ResponseBase<DtoCustomer>
                {
                    Data = null,
                    Message = $"Error:{e.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = "Hata, veriler listelenemedi"
                };
            }
        }
    }
}
