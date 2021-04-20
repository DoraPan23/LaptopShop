using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class OrderDao
    {
        LaptopShopDbContext db = null;
        public List<Order> getListAllOrder()
        {
            return db.Order.ToList();
        }
        public OrderDao()
        {
            db = new LaptopShopDbContext();
        }

        public int Insert (Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public int Insert(OrderDetail orderDetail)
        {
            db.OrderDetail.Add(orderDetail);
            db.SaveChanges();
            return orderDetail.ID;
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

        public bool Update(OrderDetail orderDetail)
        {
            try
            {
                var updateOrderDetail = db.OrderDetail.Find(orderDetail.ID);
                updateOrderDetail.ID = orderDetail.ID;
                updateOrderDetail.Order_Id = orderDetail.Order_Id;
                updateOrderDetail.Product_Id = orderDetail.Product_Id;
                updateOrderDetail.Combo_Id = orderDetail.Combo_Id;
                updateOrderDetail.Quantity = orderDetail.Quantity;
                updateOrderDetail.Price = orderDetail.Price;
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

        public List<Order> getListOrderForDate(string dateFrom, string dateTo)
        {
            string[] cutDF = dateFrom.Split('-');
            
            int day = int.Parse(cutDF[2]);
            int month = int.Parse(cutDF[1]);
            int year = int.Parse(cutDF[0]);
            DateTime dateF = new DateTime(year, month, day);

            string[] cutDT = dateTo.Split('-');
            day = int.Parse(cutDT[2]);
            month = int.Parse(cutDT[1]);
            year = int.Parse(cutDT[0]);
            DateTime dateT = new DateTime(year, month, day);

            List<Order> list = db.Order.Where(x => (x.Date > dateF && x.Date < dateT)).ToList();
            return list;
        }

        public Order getOrderById(int id)
        {
            return db.Order.Where(x => x.ID == id).SingleOrDefault();
        }

        public List<OrderDetail> getOrderDetailById(int id)
        {
            return db.OrderDetail.Where(x => x.Order_Id == id).ToList();
        }
        public List<CartFormatDao> getOrderDetail(int id)
        {
            var queryProduct = from o in db.OrderDetail
                               join p in db.Product on o.Product_Id equals p.ID
                               where o.Order_Id == id
                               select new
                               {
                                   Id = o.ID,
                                   product_id = p.ID,
                                   name = p.Product_Name,
                                   price = p.Price,
                                   discount=p.Discount,
                                   quantity = o.Quantity,
                               };
            List<CartFormatDao> list = new List<CartFormatDao>();
            foreach (var item in queryProduct)
            {
                CartFormatDao cart = new CartFormatDao();
                cart.Cart_id = item.Id;
                cart.Product_id = item.product_id;
                cart.ProductName = item.name;
                float price = (float)item.price;
                if (item.discount.HasValue)
                {
                    float discount = (float)item.discount;
                    price = price - (price * discount / 100);
                }
                cart.Price = price;
                cart.Quantity = (int)item.quantity;
                list.Add(cart);
            }
            var queryCombo = from o in db.OrderDetail
                             join cb in db.Combo on o.Combo_Id equals cb.ID
                             where o.Order_Id == id
                             select new
                             {
                                 id = o.ID,
                                 combo_Id = cb.ID,
                                 name = cb.Combo_Name,
                                 price = cb.totalMoney,
                                 discount=cb.discount,
                                 quantity = o.Quantity
                             };
            foreach (var item in queryCombo)
            {
                CartFormatDao cart = new CartFormatDao();
                cart.Cart_id = item.id;
                cart.Product_id = item.combo_Id;
                cart.ProductName = item.name;
                float price = (float)item.price;
                if (!item.discount.Equals(null))
                {
                    float discount = (float)item.discount;
                    price = price - (price * discount / 100);
                }
                cart.Price = price;
                cart.Quantity = (int)item.quantity;
                cart.Amount = 10;
                list.Add(cart);
            }
            return list;
        }

        

        //khach hang mua hang thanh cong nhieu nhat
        public string getCustomerBuyMost()
        {
            int id=0;
            foreach (var line in db.Order.Where(o => o.Status == 3)
                        .GroupBy(x => x.User_Id)
                        .Select(group => new
                        {
                            User_Id = group.Key,
                            Count = group.Count()
                        })
                        .OrderByDescending(x => x.User_Id))
            {
                id = (int)line.User_Id;
                break;
            }
            if (id == 0)
            {
                return "...";
            }
            return new UserDao().getNameUserById(id);

        }

        public string getProductBuyMost()
        {
            int sum=0,id=0;
            var productBuyMost = from o in db.Order
                                 join od in db.OrderDetail on o.ID equals od.Order_Id
                                 where o.Status == 3 && od.Product_Id > 0
                                 group od by od.Product_Id into grp
                                 select new { Product_Id = grp.Key, sum = grp.Sum(x => x.Quantity) };
            foreach(var item in productBuyMost) 
            {
                if (item.sum > sum)             // vi k them dc descending trong linq nen phai duyet tung item trong cau truy van de lay max (sum)
                {   
                    sum = (int)item.sum;
                    id = (int)item.Product_Id;
                }
                
            }
            if (id == 0)
            {
                return "...";
            }
            return  new ProductDao().getItemById(id).Product_Name;
        }

        public string getComboBuyMost()
        {
            int sum = 0, id = 0;
            var productBuyMost = from o in db.Order
                                 join od in db.OrderDetail on o.ID equals od.Order_Id
                                 where o.Status == 3 && od.Combo_Id > 0
                                 group od by od.Combo_Id into grp
                                 select new { Combo_Id = grp.Key, sum = grp.Sum(x => x.Quantity) };
            foreach (var item in productBuyMost)
            {
                if (item.sum > sum)             // vi k them dc descending trong linq nen phai duyet tung item trong cau truy van de lay max (sum)
                {
                    sum = (int)item.sum;
                    id = (int)item.Combo_Id;
                }

            }
            if (id == 0)
            {
                return "...";
            }
            return new ComboDao().getItemById(id).FirstOrDefault().ComboName;
        }

        public List<double> getRevenueByYear(int year)
        {
            List<Order> list = db.Order.ToList().Where(x => Convert.ToDateTime(x.Date).Year == year && x.Status == 3).ToList();
            List<double> listRevenue = new List<double>();
            int check = 0;
            double revenueInMonth = 0;
            double revenueInYear = 0;
            for (int i = 1; i <= 12; i++)
            {
                foreach (Order order in list)
                {
                    if (Convert.ToDateTime(order.Date).Month == i)
                    {
                        check = 1;
                        revenueInMonth = (double)(revenueInMonth + order.Total_Price);
                        
                    }
                    
                }
                if (check == 0)
                {
                    listRevenue.Add(0);
                }
                else if (check == 1)
                {
                    listRevenue.Add(revenueInMonth);
                    revenueInYear = revenueInYear + revenueInMonth;
                }
                check = 0;
                revenueInMonth = 0;
            }
            listRevenue.Add(revenueInYear);
            return listRevenue;
        }
    }
}