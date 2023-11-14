using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ProductServices
    {

        private readonly WestWindContext _context;

        internal ProductServices(WestWindContext context)
        {
            _context = context;
        }


        //Returns products with a matching category ID and puts it into a list
        public List<Product> GetProductsByCategoryID(int id)
        {
            return _context.Products.Where(p => p.CategoryId == id).Include(p => p.Supplier).ToList<Product>();
        }

        public List<Product> GetProductsByNameOrCategoryName(string partial)
        {
            partial = partial.ToLower();
            return _context.Products.Where(p => p.ProductName.ToLower().Contains(partial) || p.Category.CategoryName.ToLower().Contains(partial))
                .Include(p => p.Supplier)
                .ToList<Product>();
        }
    }
}
