using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Northwind.BusinessLogicLayer.Concrete.MapperConfiguration;
using Northwind.DataAccessLayer.Abstract.GenericRepository;
using Northwind.DataAccessLayer.Abstract.UnitOfWorkRepository;
using Northwind.EntityLayer.Abstract.IBases;
using Northwind.EntityLayer.Concrete.Bases;
using Northwind.InterfaceLayer.Abstract.GenericService.Abstract;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase
{
    public class BusinessLogicBase<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        #region Variables

        private readonly IUnitOfWorkRepository unitOfWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        private readonly Mapper mapper;

        #endregion

        public BusinessLogicBase(IServiceProvider service)
        {
            unitOfWork = service.GetService<IUnitOfWorkRepository>();
            repository = unitOfWork.GetRepository<T>();
            this.service = service;
        }
        public IResponseBase<TDto> Add(TDto entity, bool saveChanges = true)
        {
            try
            {
                var resolvedResult = " ";
                var TResult = repository.Add(ObjectMapper.Mapper.Map<T>(entity));
                resolvedResult = string.Join(',',
                    TResult.GetType().GetProperties()
                        .Select(x => $"-{x.Name}: {x.GetValue(TResult) ?? ""}-"));
                //TODO : Transactionın Dinamik olarak çalışmasını sağlar.
                if (saveChanges)
                {
                    Save();
                }
                return new ResponseBase<TDto>
                {
                    Data = ObjectMapper.Mapper.Map<T, TDto>(TResult),
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
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

        public IResponseBase<Task<TDto>> AddAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<Task<bool>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<bool> Delete(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<Task<bool>> DeleteAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<TDto> Update(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<Task<TDto>> UpdateAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<TDto> Find(int id)
        {
            try
            {
                return new ResponseBase<TDto>
                {
                    Data = ObjectMapper.Mapper.Map<T,TDto>(repository.Find(id)),
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
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

        public IResponseBase<IQueryable<T>> GetIQueryable()
        {
            throw new NotImplementedException();
        }

        public IResponseBase<List<TDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResponseBase<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            //TODO : işlemin kaydedilmesini cağırır.
            unitOfWork.SaveChanges();
        }
    }
}
