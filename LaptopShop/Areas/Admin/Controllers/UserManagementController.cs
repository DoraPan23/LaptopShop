using LaptopShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: Admin/UserManagement
        [HttpGet]
        public ActionResult Index()
        {
            //if (UserSingleTon.Instance.User.Role_ID == 3 || UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            //{
            //    return RedirectToAction("Index", "../Home");
            //}
            var model = new UserDao().GetListUser();
            ViewBag.role = new RoleDao().getListRole();
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Index(FormCollection form)
        //{
        //    int ID_User = int.Parse(form["id"]);
        //    int role = new RoleDao().getIdByName(form["role"]);
        //    //string status = form["status"];
        //    //bool status1 = (bool) status;
        //    bool status = bool.Parse(form["status"]);
        //    new UserDao().Update(ID_User, role, status);
        //    var model = new UserDao().GetListUser();
        //    ViewBag.role = new RoleDao().getListRole();
        //    return View(model);
        //}
    }
}