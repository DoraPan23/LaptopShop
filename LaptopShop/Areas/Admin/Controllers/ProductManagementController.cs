using LaptopShop.Models;
using LaptopShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class ProductManagementController : Controller       // con loi UI chon brand, khi chon san pham co catalog khong phai lap top thi phai an cai selectlist cua brand
    {
        // GET: Admin/ProductManagement
        ProductDao dao = new ProductDao();
        public ActionResult Index()
         {
            if (UserSingleTon.Instance.User.Role_ID == 3|| UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            {
                return RedirectToAction("Index", "../Home");
            }
            var model = dao.getListAllProduct();
            return View(model);
        }

        public ActionResult AddProduct()
         {
            if (UserSingleTon.Instance.User.Role_ID == 3 || UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            {
                return RedirectToAction("Index", "../Home");
            }
            SelectList CategoryList = new SelectList(new CatalogDao().getListCatalog(), "ID", "Catalog_Name");
            ViewBag.CategoryList = CategoryList;
            SelectList BrandList = new SelectList(new BrandDao().getListBrand().Where(x=>x.Brand_Name!="0"), "ID", "Brand_Name",3);
            ViewBag.BrandList = BrandList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string path="";
                    string folderCatalog = "";
                    string folderBrand = "";

                    string catalog_Id= collection["Catalog"];
                    Product product = new Product();
                    product.Product_Name = collection["Product_Name"];
                    product.Catalog_ID =Convert.ToInt32(collection["Catalog"]);
                    product.Amount = Convert.ToInt32(collection["Amount"]);
                    product.Price = Convert.ToDecimal(collection["Price"]);
                    product.Discount = (double)Convert.ToDecimal(collection["Discount"]);
                    product.Detail = collection["Detail"];
                    if (product.Catalog_ID == 6)    /// co brand hay k phu thuoc vao catalog la laptop thi se co brand
                    {
                        product.Brand_ID = Convert.ToInt32(collection["Brand"]);
                    }
                    else
                    {
                        product.Brand_ID = 3; // =3 la k co brand
                    }
                    var listCatalog = new CatalogDao().getListCatalog();
                    foreach (var item in listCatalog)
                    {
                        if (item.ID == product.Catalog_ID)
                        {
                            folderCatalog = item.Catalog_Name;
                            break;
                        }
                    }
                    var listBrand = new BrandDao().getListBrand();
                    foreach (var item in listBrand)
                    {
                        if (item.ID == product.Brand_ID)
                        {
                            folderBrand = item.Brand_Name;
                            break;
                        }
                    }
                    //upload file
                    if (file != null && file.ContentLength > 0)
                        try
                        {
                            if (folderCatalog == "Laptop")
                            {
                                path = Path.Combine(Server.MapPath("../../images/" + folderCatalog+"/"+folderBrand),
                                                       Path.GetFileName(file.FileName));
                            }
                            else
                            {
                                path = Path.Combine(Server.MapPath("../../images/" + folderCatalog),
                                                       Path.GetFileName(file.FileName));
                            }
                            //path = "C:\\Users\\ASUS\\OneDrive\\Desktop\\LaptopShop\\images";
                            file.SaveAs(path);
                            ViewBag.Message = "File uploaded successfully";
                            //cap nhat lai path image trong database
                            if (folderCatalog == "Laptop")
                            {
                                product.Image = "/images/" + folderCatalog + "/" + folderBrand + "/" + file.FileName;
                            }
                            else
                            {
                                product.Image = "/images/" + folderCatalog + "/" + file.FileName;
                            }
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "ERROR:" + ex.Message.ToString();
                        }
                    else
                    {
                        ViewBag.Message = "You have not specified a file.";
                    }




                    
                    long id = dao.Insert(product);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "ProductManagement");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Fail");
                    }
                }
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (UserSingleTon.Instance.User.Role_ID == 3 || UserSingleTon.Instance.User.Role_ID == 0)        // kiem tra session, neu chua dang nhap la id = 0
            {
                return RedirectToAction("Index", "../Home");
            }
            var model = new ProductDao().getDetailProduct(id);
            SelectList CategoryList = new SelectList(new CatalogDao().getListCatalog(), "ID", "Catalog_Name",model.Catalog_ID);
            ViewBag.CategoryList = CategoryList;
            SelectList BrandList = new SelectList(new BrandDao().getListBrand(), "ID", "Brand_Name",model.Brand_ID);
            ViewBag.BrandList = BrandList;
            ViewBag.TestDataLog_id = "";
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string path = "";
                    string folderCatalog = "";
                    string folderBrand = "";


                    Product product = new Product();
                    product.ID = Convert.ToInt32(collection["ID"]);
                    product.Product_Name = collection["Product_Name"];
                    product.Catalog_ID = Convert.ToInt32(collection["Catalog"]);
                    product.Amount = Convert.ToInt32(collection["Amount"]);
                    product.Price = Convert.ToDecimal(collection["Price"]);
                    
                    product.Discount = (double)Convert.ToDecimal(collection["Discount"]);
                    product.Detail = collection["Detail"];
                    product.Brand_ID = Convert.ToInt32(collection["Brand"]);
                    if (product.Catalog_ID == 6)    /// co brand hay k phu thuoc vao catalog la laptop thi se co brand
                    {
                        product.Brand_ID = Convert.ToInt32(collection["Brand"]);
                    }
                    else
                    {
                        product.Brand_ID = 3; // =3 la k co brand
                    }
                    var listCatalog = new CatalogDao().getListCatalog();
                    foreach (var item in listCatalog)
                    {
                        if (item.ID == product.Catalog_ID)
                        {
                            folderCatalog = item.Catalog_Name;
                            break;
                        }
                    }
                    var listBrand = new BrandDao().getListBrand();
                    foreach (var item in listBrand)
                    {
                        if (item.ID == product.Brand_ID)
                        {
                            folderBrand = item.Brand_Name;
                            break;
                        }
                    }
                    //upload file
                    if (file != null && file.ContentLength > 0)
                        try
                        {
                            if (folderCatalog == "Laptop")
                            {
                                path = Path.Combine(Server.MapPath("../../../images/" + folderCatalog + "/" + folderBrand),
                                                       Path.GetFileName(file.FileName));
                            }
                            else
                            {
                                path = Path.Combine(Server.MapPath("../../images/" + folderCatalog),
                                                       Path.GetFileName(file.FileName));
                            }
                            //path = "C:\\Users\\ASUS\\OneDrive\\Desktop\\LaptopShop\\images";
                            file.SaveAs(path);
                            ViewBag.Message = "File uploaded successfully";
                            //cap nhat lai path image trong database
                            if (folderCatalog == "Laptop")
                            {
                                product.Image = "/images/" + folderCatalog + "/" + folderBrand + "/" + file.FileName;
                            }
                            else
                            {
                                product.Image = "/images/" + folderCatalog + "/" + file.FileName;
                            }
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "ERROR:" + ex.Message.ToString();
                        }
                    else
                    {
                        product.Image = collection["Image"];
                    }
                    //string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    //string extension = Path.GetExtension(product.ImageFile.FileName);
                    //product.Image = Path.Combine(Server.MapPath("../image" + folderImg + fileName));
                    //product.ImageFile.SaveAs(product.Image);

                    dao.Update(product);
                    return RedirectToAction("Index", "ProductManagement");
                }
                return View("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}