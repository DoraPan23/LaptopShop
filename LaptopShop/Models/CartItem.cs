using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models
{
    [Serializable]
    public class CartItem
    {
        
        public Product product { get; set; }
        public int quantity { get; set; }
    }
}