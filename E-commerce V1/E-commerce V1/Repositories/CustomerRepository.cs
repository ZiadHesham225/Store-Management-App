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
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(ECommerceContext db) : base(db) { }

        public override Customer GetById(int id)
        {
            return dbSet.Include(c => c.Orders).FirstOrDefault(c => c.Id == id);
        }
    }

}
