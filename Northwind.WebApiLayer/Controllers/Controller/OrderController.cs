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
    public class OrderController : BaseController<IOrderService, Order, DtoOrder>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService service, IOrderService orderService) : base(service)
        {
            _orderService = orderService;
        }
    }
}
