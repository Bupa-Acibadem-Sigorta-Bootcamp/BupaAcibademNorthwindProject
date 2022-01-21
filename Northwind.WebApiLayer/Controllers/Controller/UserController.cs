using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Northwind.EntityLayer.Abstract.IBases;
using Northwind.EntityLayer.Concrete.Bases;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Dtos.DtoTokenOperations;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.WebApiLayer.Controllers.Controller
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IResponseBase<DtoUserToken> Login(DtoLogin login)
        {
            try
            {
                return _userService.Login(login);
            }
            catch (Exception)
            {
                return new ResponseBase<DtoUserToken>
                {
                    Data = null,
                    Message = "Error",
                    ErrorMessage = "Email or Password is wrong",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public IResponseBase<DtoUser> Register(DtoUser register)
        {
            try
            {
                return _userService.Register(register);
            }
            catch (Exception)
            {
                return new ResponseBase<DtoUser>
                {
                    Data = null,
                    Message = "Error",
                    ErrorMessage = "Email or Password is wrong",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}

