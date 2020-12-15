using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class UserDao
    {
        LaptopShopDbContext db = null;
        public UserDao()
        {
            db = new LaptopShopDbContext();
        }

        public int Insert(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return user.ID;
        }

        public User GetByName(string userName)
        {
            return db.User.SingleOrDefault(x => x.username == userName);
            //return db.User.Where(x => x.username == username).SingleOrDefault();
        }

        public bool Delete(int id)
        {
            try
            {
                var cus = db.User.Find(id);
                db.User.Remove(cus);
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
            var result = db.User.SingleOrDefault(x => x.username == username);
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

        public int SignUp(string user)
        {
            var result = db.User.SingleOrDefault(x => x.username == user);
            if (result != null)
            {
                return 0;
            }
            return 1;
        }
    }
}