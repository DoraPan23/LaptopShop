using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models.Dao
{
    public class UserSingleTon
    {
        private static readonly UserSingleTon instance = new UserSingleTon();
        private Customer user;
        static UserSingleTon()
        {
        }
        private UserSingleTon()
        {
            User = new Customer();
        }
        public static UserSingleTon Instance
        {
            get
            {
                return instance;
            }
        }

        public Customer User { get; set; }
    }
}