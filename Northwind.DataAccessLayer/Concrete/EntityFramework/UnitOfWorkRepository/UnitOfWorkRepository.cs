using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Northwind.DataAccessLayer.Abstract.GenericRepository;
using Northwind.DataAccessLayer.Abstract.UnitOfWorkRepository;
using Northwind.DataAccessLayer.Concrete.EntityFramework.GenericRepository;
using Northwind.EntityLayer.Concrete.Bases;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework.UnitOfWorkRepository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        #region Variables

        private DbContext context;
        private IDbContextTransaction transaction;
        bool dispose;

        public UnitOfWorkRepository(DbContext context)
        {
            this.context = context;
        }

        #endregion
        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            //TODO : T tipinde nesneyi üretip Bll'e gönderiyor. Repsository nesnesinde dinanmik nesne kullanılıyor.
            return new EfGenericRepository<T>(context);
        }

        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            var _transaction = this.transaction != null ? this.transaction : context.Database.BeginTransaction();
            using (_transaction)
            {
                try
                {
                    if (context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }

                    //TODO : işlemler başarılıysa hepsini kaydeder.
                    int result = context.SaveChanges();
                    //TODO : tüm işlemler başarılıysa onaylar.
                    _transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    //TODO : Hata olduğunda işlemi geri alır.
                    transaction.Rollback();
                    throw new Exception("Error on save changes", e);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            //TODO : Durum dispose edilmemişse 
            if (!this.dispose) 
            {
                if (disposing) //TODO :  dispose et 
                {
                    context.Dispose();
                }
            }
            //TODO : Defeault dispose edilecek bir şey var
            this.dispose = true;
        }
        public void Dispose()
        {
            //TODO : Dispose true ise bellekte kullanılmayan veri hala duruyorsa sil
            Dispose(true);
            //TODO : Garbage Collector tetikler
            GC.SuppressFinalize(this);
        }
    }
}
