using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.EntityLayer.Abstract.IBases;
using Northwind.EntityLayer.Concrete.Bases;
using Northwind.InterfaceLayer.Abstract.GenericService.Abstract;

namespace Northwind.WebApiLayer.Controllers.BaseController
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BaseController<TInterface, T, TDto> : ControllerBase
        where TInterface : IGenericService<T, TDto>
        where T : EntityBase
        where TDto : DtoBase
    {
        private readonly TInterface _service;

        public BaseController(TInterface service)
        {
            _service = service;
        }

        [HttpGet("Find")]
        public IResponseBase<TDto> Find(int id)
        {
            try
            {
                var entity = _service.Find(id);
                return entity;
            }
            catch (Exception e)
            {
                return new ResponseBase<TDto>
                {
                    Data = null,
                    Message = $"Error:{e.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
        [HttpGet("GetAll")]
        public IResponseBase<List<TDto>> GetAll()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception e)
            {
                return new ResponseBase<List<TDto>>
                {
                    Data = null,
                    Message = $"Error:{e.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
