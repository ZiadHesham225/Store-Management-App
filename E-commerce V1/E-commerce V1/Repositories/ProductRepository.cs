using E_commerce_V1.Context;
using E_commerce_V1.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_V1.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ECommerceContext db) : base(db) { }

        public override List<Product> GetAll()
        {
            return dbSet.Include(p => p.Category).ToList();
        }

        public override Product GetById(int id)
        {
            return dbSet.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }
    }

}
