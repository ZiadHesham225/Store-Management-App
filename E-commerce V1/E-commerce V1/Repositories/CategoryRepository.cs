using E_commerce_V1.Context;
using E_commerce_V1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_V1.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(ECommerceContext db) : base(db) { }
    }

}
