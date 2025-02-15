﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models
{
    public class ProductDao
    {
        LaptopShopDbContext db = null;
        public ProductDao()
        {
            db = new LaptopShopDbContext();
        }
        public List<Product> getListProductLaptop(int quantity)
        {
            return db.Product.Where(x=>x.Catalog_ID==6).Take(quantity).ToList();
        }
    }
}