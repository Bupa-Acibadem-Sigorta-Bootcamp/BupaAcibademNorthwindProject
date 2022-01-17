using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Northwind.EntityLayer.Abstract.IBases;

namespace Northwind.InterfaceLayer.Abstract.GenericService.Abstract
{
    public interface IGenericService<T, TDto> where T : IEntityBase where TDto : IDtoBase
    {
        IResponseBase<TDto> Add(TDto entity, bool saveChanges = true);
        IResponseBase<Task<TDto>> AddAsync(TDto entity);
        IResponseBase<bool> DeleteById(int id, bool saveChanges = true);
        IResponseBase<Task<bool>> DeleteByIdAsync(int id);
        IResponseBase<bool> Delete(TDto entity);
        IResponseBase<Task<bool>> DeleteAsync(TDto entity);
        IResponseBase<TDto> Update(TDto entity);
        IResponseBase<Task<TDto>> UpdateAsync(TDto entity);
        IResponseBase<TDto> Find(int id);
        IResponseBase<IQueryable<T>> GetIQueryable();
        IResponseBase<List<TDto>> GetAll();
        IResponseBase<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        void Save();
    }
}
