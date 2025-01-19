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
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(ECommerceContext db) : base(db) { }

        public override List<Order> GetAll()
        {
            return dbSet.Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                        .Include(o => o.Customer)
                        .ToList();
        }

        public override Order GetById(int id)
        {
            return dbSet.Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                        .Include(o => o.Customer)
                        .FirstOrDefault(o => o.Id == id);
        }
    }

}
