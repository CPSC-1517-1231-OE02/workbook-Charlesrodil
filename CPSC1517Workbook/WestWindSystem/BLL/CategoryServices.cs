﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestWindSystem.Entities;
using WestWindSystem.DAL;


namespace WestWindSystem.BLL
{
    public class CategoryServices
    {

        private readonly WestWindContext _context;

        internal CategoryServices(WestWindContext context) 
        { 
            _context = context;
        }


        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList<Category>();
        }
    }
}
