using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.BusinessLogicLayer.Concrete.MapperConfiguration;
using Northwind.BusinessLogicLayer.Concrete.TokenOperation;
using Northwind.DataAccessLayer.Abstract.IRepository;
using Northwind.EntityLayer.Abstract.IBases;
using Northwind.EntityLayer.Concrete.Bases;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Dtos.DtoTokenOperations;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class UserManager : BusinessLogicBase<User, DtoUser>, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public UserManager(IServiceProvider service, IUserRepository userRepository, IConfiguration configuration) : base(service)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public IResponseBase<DtoUserToken> Login(DtoLogin dtoLogin)
        {
            var user = _userRepository.Login(ObjectMapper.Mapper.Map<User>(dtoLogin));
            
            if (user != null)
            {
                var dtouser = ObjectMapper.Mapper.Map<DtoLoginUser>(user);
                var token = new TokenManager(_configuration).CreateAccessToken(dtouser);
                var usertoken = new DtoUserToken()
                {
                    DtoLoginUser = dtouser,
                    AccessToken = token
                };
                return new ResponseBase<DtoUserToken>
                {
                    Data = usertoken,
                    Message = "Success",
                    SuccessMessage = "Token is success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new ResponseBase<DtoUserToken>
                {
                    Data = null,
                    Message = "Error",
                    ErrorMessage = "Email or Password is wrong",
                    StatusCode = StatusCodes.Status406NotAcceptable
                };
            }
        }
    }
}
