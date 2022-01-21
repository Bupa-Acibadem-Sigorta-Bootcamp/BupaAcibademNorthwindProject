using System;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class UserOperationClaimManager : BusinessLogicBase<UserOperationClaim, DtoUserOperationClaim>, IUserOperationClaimService
    {
        public UserOperationClaimManager(IServiceProvider service) : base(service)
        {
        }
    }
}