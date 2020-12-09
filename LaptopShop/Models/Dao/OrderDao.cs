using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class OrderDao
    {
        LaptopShopDbContext db = null;
        public OrderDao()
        {
            db = new LaptopShopDbContext();
        }

        public bool Insert (Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return true;
        }

        public bool Update(Order order)
        {
            try
            {
                var updateOrder = db.Order.Find(order.ID);
                updateOrder.ID = order.ID;
                updateOrder.Date = order.Date;
                updateOrder.Cart_Id = order.Cart_Id;
                updateOrder.Customer_Id = order.Customer_Id;
                updateOrder.Status = order.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Order> getListOrderForCustomer(int id)
        {
            return db.Order.Where(x => x.Customer_Id == id).ToList();
        }
    }
}