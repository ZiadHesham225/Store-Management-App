using E_commerce_V1.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_V1.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ECommerceContext db;
        protected DbSet<T> dbSet;
        public Repository(ECommerceContext _db)
        {
            db = _db;
            dbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
            db.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            db.SaveChanges();
        }
    }
}
