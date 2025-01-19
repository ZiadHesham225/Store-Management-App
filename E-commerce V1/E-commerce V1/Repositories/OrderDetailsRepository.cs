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
    public class OrderDetailsRepository : Repository<OrderDetails>
    {
        public OrderDetailsRepository(ECommerceContext db) : base(db) { }

        public override List<OrderDetails> GetAll()
        {
            return dbSet.Include(od => od.Product)
                        .Include(od => od.Order)
                        .ToList();
        }

        public override OrderDetails GetById(int id)
        {
            return dbSet.Include(od => od.Product)
                        .Include(od => od.Order)
                        .FirstOrDefault(od => od.Id == id);
        }
    }

}
