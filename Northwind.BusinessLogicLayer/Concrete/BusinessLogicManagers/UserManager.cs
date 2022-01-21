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
using Northwind.BusinessLogicLayer.Concrete.Md5HashOperation;
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
            //TODO : Kullanicinin girdigi parola sifrelenir ve veri tabaninda parolanin sifrelenmis haliyle karsilastirilir
            var login = new DtoLogin
            {
                Email = dtoLogin.Email,
                PasswordHash = Md5HashGenerator.MD5Hash(dtoLogin.PasswordHash)
            };

            var user = _userRepository.Login(ObjectMapper.Mapper.Map<User>(login));

            if (user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLoginUser>(user);
                var token = new TokenManager(_configuration).CreateAccessToken(dtoUser);
                var userToken = new DtoUserToken()
                {
                    DtoLoginUser = dtoUser,
                    AccessToken = token
                };
                return new ResponseBase<DtoUserToken>
                {
                    Data = userToken,
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

        public IResponseBase<DtoUser> Register(DtoUser register, bool saveChanges = true)
        {
            try
            {
                var encryptedPassword = new DtoUser
                {
                    Email = register.Email,
                    PasswordHash = Md5HashGenerator.MD5Hash(register.PasswordHash),
                    FirstName = register.FirstName,
                    LastName = register.LastName

                };
                var resolvedResult = " ";
                var TResult = _userRepository.Register(ObjectMapper.Mapper.Map<User>(encryptedPassword));
                resolvedResult = string.Join(',',
                    TResult.GetType().GetProperties()
                        .Select(x => $"-{x.Name}: {x.GetValue(TResult) ?? ""}-"));
                //TODO : Transactionın Dinamik olarak çalışmasını sağlar.
                if (saveChanges)
                {
                    Save();
                }
                return new ResponseBase<DtoUser>
                {
                    SuccessMessage = "User has been registered successfully",
                    ErrorMessage = "No error",
                    Data = ObjectMapper.Mapper.Map<User, DtoUser>(TResult),
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception)
            {
                return new ResponseBase<DtoUser>
                {
                    ErrorMessage = "User registration is incorrect",
                    Data = null,
                    Message = "Error",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
