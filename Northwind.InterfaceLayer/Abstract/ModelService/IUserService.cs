using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.EntityLayer.Abstract.IBases;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Dtos.DtoTokenOperations;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.GenericService.Abstract;

namespace Northwind.InterfaceLayer.Abstract.ModelService
{
    public interface IUserService : IGenericService<User, DtoUser>
    {
        IResponseBase<DtoUserToken> Login(DtoLogin dtoLogin);
    }
}