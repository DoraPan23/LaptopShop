using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models
{
    public class ProductFormatDao
    {
        int id,amount;
        string product_Name,catalog_Name,detail,image,brand_Name;
        decimal price;
        float discount;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int Amount 
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
        public string Product_Name
        {
            get
            {
                return product_Name;
            }
            set
            {
                product_Name = value;
            }
        }
        public string Catalog_Name
        {
            get
            {
                return catalog_Name;
            }
            set
            {
                catalog_Name = value;
            }
        }
        public string Detail
        {
            get
            {
                return detail;
            }

            set
            {
                detail = value;
            }
        }
        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }
        public string Brand_Name
        {
            get
            {
                return brand_Name;
            }

            set
            {
                brand_Name = value;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public float Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }
    }
}