using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models
{
    public class CartFormatDao
    {
        int cart_id;
        int product_id;
        string linkImage;
        string productName;
        double price;
        int amount;
        int quantity;

        public string LinkImage
        {
            get
            {
                return linkImage;
            }

            set
            {
                linkImage = value;
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public int Product_id
        {
            get
            {
                return product_id;
            }

            set
            {
                product_id = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public int Cart_id
        {
            get
            {
                return cart_id;
            }

            set
            {
                cart_id = value;
            }
        }
    }
}