using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;
using Northwind.WebApiLayer.Controllers.BaseController;

namespace Northwind.WebApiLayer.Controllers.Controller
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomerController : BaseController<ICustomerService, Customer, DtoCustomer >
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService service, ICustomerService customerService) : base(service)
        {
            _customerService = customerService;
        }
        /*
        [HttpGet("GetByStringId")]
        public IResponseBase<DtoCustomer> GetByStringId(string id)
        {
            try
            {
                var entity = _customerService.GetByStringId(id);
                return entity;
            }
            catch (Exception e)
            {
                return new ResponseBase<DtoCustomer>
                {
                    Data = null,
                    Message = $"Error:{e.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
        */
        [HttpGet("GetByStringId")]
        public IActionResult GetByStringId(string id)
        {
            var result = _customerService.GetByStringId(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
