﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class ComboDao
    {
        LaptopShopDbContext db = null;
        public ComboDao()
        {
            db = new LaptopShopDbContext();
        }

        public List<Combo> getListCombo()
        {
            return db.Combo.ToList();
        }

        public List<ComboFormatDao> getItemById(int id)
        {
            List<int> idProduct = new List<int>();
            List<string> nameProduct = new List<string>();
            List<double> priceProduct = new List<double>();
            var query = db.Combo.Where(x => x.ID == id).SingleOrDefault();
            var query1 = db.Product.ToList();
            string[] data = query.Product_List.Split(new string[] { ";" }, StringSplitOptions.None);
            foreach(string item in data)
            {
                foreach(var product in query1)
                {
                    if (item == product.ID.ToString())
                    {
                        nameProduct.Add(product.Product_Name);
                        idProduct.Add(product.ID);
                        if (product.Discount != null)
                        {
                            priceProduct.Add(Decimal.ToDouble((decimal)product.Price)-Convert.ToDouble(Decimal.ToDouble((decimal)product.Price) * product.Discount/100));
                        }
                        else
                        {
                            priceProduct.Add((double)product.Price);
                        }
                    }
                }
            }

            List<ComboFormatDao> list = new List<ComboFormatDao>();
            for(int i=0;i<nameProduct.Count;i++)
            {
                ComboFormatDao cb = new ComboFormatDao();
                cb.ProductId = idProduct[i];
                cb.ComboId = query.ID;
                cb.ComboName = query.Combo_Name;
                cb.Discount = query.discount;
                cb.ProductName = nameProduct[i];
                cb.StartDate = query.startDate;
                cb.EndDate = query.endDate;
                cb.ProductPrice = priceProduct[i];
                cb.Image = query.Image;
                list.Add(cb);
            }
            return list;
        }
    }
}