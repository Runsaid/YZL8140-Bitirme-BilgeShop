using BilgeShop.Data.Context;
using BilgeShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Data.Repositories
{
    // Generic Repository Pattern
    public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BilgeShopContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public SqlRepository(BilgeShopContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            _db.SaveChanges();

            // Projemde artık DbContext'e CRUD işlemi yapılırken , repository üzerinden yapılacağı için , ne kadar istenilirse istenilsin, Hard Delete yapılamayacak.

            
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);


            // _db.Products.FirstOrDefault(x => x.Name.StartsWith("Ap"));
            // Products tablosu üzerinde , adı Ap ile başlayan ürünlerden ilkini getir.

           
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            // _dbset.GetAll(); -> koşulsuz , hepsi gelsin.
            // _dbset.GetAll(x => x.IsDeleted == false) -> silinmemiş olanları getirsin.

            return predicate is not null ? _dbSet.Where(predicate) : _dbSet;

            // ToList() -> nesneleri - Iqueryable -> sorguyu döner. Ben burada sorguyu dönmek istiyorum.

            // List olarak çekersem, sorgu üzerinde ilaveler yapamam , fakat bana sorgu olarak döndürürse, ben ilave olarak select / where gibi ilave sorgular çalıştırabilirim.
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
            _db.SaveChanges();
        }
    }
}
