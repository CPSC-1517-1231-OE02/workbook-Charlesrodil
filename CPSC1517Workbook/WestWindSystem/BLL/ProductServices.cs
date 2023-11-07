﻿using System;
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
            return _context.Products.Where(p => p.CategoryId == id).ToList<Product>();  
        }

    }
}
