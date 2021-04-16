using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class BrandDao
    {
        LaptopShopDbContext db = null;
        public BrandDao()
        {
            db = new LaptopShopDbContext();
        }

        public List<Brand> getListBrand()
        {
            return db.Brand.ToList();
        }
    }
}