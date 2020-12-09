using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class CustomerDao
    {
        LaptopShopDbContext db = null;
        public CustomerDao()
        {
            db = new LaptopShopDbContext();
        }

        public int Insert(Customer cus)
        {
            db.Customer.Add(cus);
            db.SaveChanges();
            return cus.ID;
        }

        public Customer GetByName(string username)
        {
            return db.Customer.Where(x => x.username == username).SingleOrDefault();
        }

        public bool Delete(int id)
        {
            try
            {
                var cus = db.Customer.Find(id);
                db.Customer.Remove(cus);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



        public int Login(string username, string password)
        {
            var result = db.Customer.SingleOrDefault(x => x.username == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.password == password)
                {
                    return 1;
                }
                else return -2;
            }
        }

        public int SignUp(string user, string pass1, string pass2)
        {
            var result = db.Customer.SingleOrDefault(x => x.username == user);
            if(user.Equals("") && result == null)
            {
                return 0;
            }
            else if (pass1.Equals(pass2))
            {
                return 1;
            }
            return 0;
        }
    }
}