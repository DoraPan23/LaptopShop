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
                updateOrder.User_Id = order.User_Id;
                updateOrder.Status = order.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Order> getListOrderForUser(int id)
        {
            return db.Order.Where(x => x.User_Id == id).ToList();
        }
    }
}