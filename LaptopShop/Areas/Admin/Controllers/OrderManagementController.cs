using LaptopShop.Models;
using LaptopShop.Models.Dao;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class OrderManagementController : Controller
    {
        // GET: Admin/OrderMangement
        public ActionResult Detail(int id)
        {
            if (UserSingleTon.Instance.User.Role_ID == 3 || UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            {
                return RedirectToAction("Index", "../Home");
            }
            List<OrderDetail> listOrderDetail = new OrderDao().getOrderDetailById(id);
            
            List<Combo> listCombo = new List<Combo>();
            List<Product> listProduct = new List<Product>();
            int?[] quantity = new int?[listOrderDetail.Count];
            double?[] price = new double?[listOrderDetail.Count];
            int count = 0;
            foreach (var orDe in listOrderDetail)
            {
                if (orDe.Combo_Id != null)
                {

                    listCombo.Add(new ComboDao().getItemyById(orDe.Combo_Id));
                    quantity[count] = orDe.Quantity;
                    price[count] = orDe.Price;
                    count++;
                }

                if (orDe.Product_Id != null)
                {
                    int proId = (int) (orDe.Product_Id);
                    Product pro = new ProductDao().getItemById(proId);
                    listProduct.Add(pro);
                    quantity[count] = orDe.Quantity;
                    price[count] = orDe.Price;
                    count++;
                }
            }
            ViewBag.listCombo = listCombo;
            ViewBag.listProduct = listProduct;
            ViewBag.quantity = quantity;
            ViewBag.price = price;
            return View();
        }
        public ActionResult Edit(int id)
        {
            if (UserSingleTon.Instance.User.Role_ID == 3 || UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            {
                return RedirectToAction("Index", "../Home");
            }
            var model = new OrderDao().getOrderById(id);
            ViewBag.Status = model.Status;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(FormCollection formCollection)
        {
            Order orderD = new Order();
            orderD.ID = int.Parse(formCollection["ID"]);
            orderD.Date = Convert.ToDateTime(formCollection["Date"]);
            orderD.Total_Price = Convert.ToDouble(formCollection["Total_Price"]);
            orderD.User_Id = int.Parse(formCollection["User_Id"]);
            orderD.Status = int.Parse(formCollection["Status"]);
            bool check=new OrderDao().Update(orderD);
            return RedirectToAction("Index", "OrderMangement");
        }
        public ActionResult Index()
        {
            if (UserSingleTon.Instance.User.Role_ID == 3 || UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            {
                return RedirectToAction("Index", "../Home");
            }
            OrderDao order = new OrderDao();
            var model = order.getListAllOrder();
            return View(model);
        }
        public ActionResult Find(string id)
        {
            if (UserSingleTon.Instance.User.Role_ID == 3 || UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            {
                return RedirectToAction("Index", "../Home");
            }
            ViewBag.date = id;
            String[] date = id.Split('_');
            OrderDao order = new OrderDao();
            var modal = order.getListOrderForDate(date[0], date[1]);
            return View(modal);
        }
    }
}