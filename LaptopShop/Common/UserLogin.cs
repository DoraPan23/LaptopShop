using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Common
{
    [Serializable]
    public class UserLogin
    {
        public string username { get; set; }
        public int ID { get; set; }
    }
}