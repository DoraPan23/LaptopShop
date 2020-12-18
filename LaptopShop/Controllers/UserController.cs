
using LaptopShop.Common;
using LaptopShop.Models;
using LaptopShop.Models.Dao;
using System;
﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopShop.Models.Dao;
using LaptopShop.Models;
using LaptopShop.Common;
using System;

namespace LaptopShop.Controllers
{
    public class UserController : Controller
    {
        OrderDao orderDao = new OrderDao();
        CartDao cartDao = new CartDao();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.username, model.password); ;
                if (result == 1)
                {
                    var user = dao.GetByName(model.username);
                    UserSingleTon.Instance.User = user;
                    var userSession = new UserLogin();
                    userSession.username = user.username;
                    userSession.ID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    new CartDao().DeleteAll();
                    return RedirectToAction("Index","Home", new { id = 1 });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { id = 2 });
                    //ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult SignOut()
        {
            Session[CommonConstants.USER_SESSION] = null;
            UserSingleTon.Instance.User = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    var user = collection["username"];
                    var pass1 = collection["password"];
                    var pass2 = collection["Confirm Password"];
                    var g = collection["gender"];
                    var result = dao.SignUp(user);
                    User userN = new User();
                    if (result == 1)
                    {
                        userN.username = user;
                        userN.password = pass1;
                        userN.firstName = collection["firstname"];
                        userN.lastName = collection["lastname"];
                        if (g.Equals("Male"))
                            userN.gender = true;
                        else
                            userN.gender = false;
                        try
                        {
                            userN.birthDate = Convert.ToDateTime(collection["birth"]);
                        }
                        catch
                        {
                            userN.birthDate = Convert.ToDateTime("1-1-1999");
                        }

                        userN.address = collection["address"];
                        userN.joinDate = DateTime.Now;
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    userN.Role_ID = 3;
                    long id = dao.Insert(userN);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Fail");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public ActionResult AddOrder()
        {
             Order order = new Order();
            var record = cartDao.getListCart();
            order.User_Id = UserSingleTon.Instance.User.ID;
            order.Date = DateTime.Now;
            order.Status = 1;   // 1 la tiep la tiep nhan don hang
            int id=orderDao.Insert(order);
            float totalPrice = 0,price;
            foreach (var item in record)
            {
                OrderDetail orderDetail = new OrderDetail();
                if (item.Product_Id != null)
                {
                    orderDetail.Product_Id = item.Product_Id;
                    price = new ProductDao().getPriceProduct((int)item.Product_Id);
                }
                else
                {
                    orderDetail.Combo_Id = item.Combo_Id;
                    price = new ProductDao().getPriceCombo((int)item.Combo_Id);
                }
                
                orderDetail.Quantity = item.Quantity;
                
                totalPrice = totalPrice + price*(float)orderDetail.Quantity;        // them total price cho bang order
                orderDetail.Price = price;
                orderDetail.Order_Id = id;
                orderDao.Insert(orderDetail);
            }
            order.Total_Price = totalPrice;             
            orderDao.Update(order);
            return RedirectToAction("ViewOrder");
        }
        public ActionResult ViewOrder()
        {
            var model = orderDao.getListOrderForUser(UserSingleTon.Instance.User.ID);
            
            if (model.Count>0)
            {
                ViewBag.OrderDetail = orderDao.getOrderDetail(model[0].ID);
            }
            
            return View(model);
        }

        public ActionResult UserInfo()
        {
            var model = new UserDao().GetListUserById(UserSingleTon.Instance.User.ID);
            return View(model);
        
        }

        public ActionResult UpdatePassword(string newPass)      // cap nhat pass cua user
        {
            // chua kiem tra mat khau cu co trung khop khong


            User user = new UserDao().GetUserById(UserSingleTon.Instance.User.ID);
            user.password = newPass;    //ma hoa
            new UserDao().Update(user);
            return RedirectToAction("UserInfo");
        }

        public ActionResult UpdateOrder(int id)     //huy don hang
        {
            Order order = orderDao.getOrderById(id);
            order.Status = 4;
            orderDao.Update(order);
            return RedirectToAction("ViewOrder");
        }

        public ActionResult ViewOrderDetail(int id)
        {
            var model = new OrderDao().getOrderDetail(id);
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderList()
        {
            if (UserSingleTon.Instance.User != null)
            {
                ViewBag.UserName = UserSingleTon.Instance.User.lastName;
            }
            return PartialView();
        }
    }
}