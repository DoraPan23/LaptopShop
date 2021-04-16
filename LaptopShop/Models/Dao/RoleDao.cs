using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class RoleDao
    {
        LaptopShopDbContext db = null;
        public RoleDao()
        {
            db = new LaptopShopDbContext();
        }
        public List<Role> getListRole()
        {
            return db.Role.ToList();
        }
        public int getIdByName(string name)
        {
            Role role = db.Role.Where(x => x.Role_Name == name).SingleOrDefault();
            return role.ID;
        }
    }
}