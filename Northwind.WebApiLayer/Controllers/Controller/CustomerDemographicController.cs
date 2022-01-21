using Microsoft.AspNetCore.Mvc;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;
using Northwind.WebApiLayer.Controllers.BaseController;

namespace Northwind.WebApiLayer.Controllers.Controller
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomerDemographicController : BaseController<ICustomerDemographicService, CustomerDemographic, DtoCustomerDemographic>
    {
        public CustomerDemographicController(ICustomerDemographicService service) : base(service)
        {
        }
    }
}