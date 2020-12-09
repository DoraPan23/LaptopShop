using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.Models
{
    public class ComboFormatDao
    {
        int productId;
        int comboId;
        string comboName;
        int discount;
        string productName;
        double productPrice;
        DateTime startDate;
        DateTime endDate;

        public string ComboName
        {
            get
            {
                return comboName;
            }

            set
            {
                comboName = value;
            }
        }

        public int Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
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

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        public double ProductPrice
        {
            get
            {
                return productPrice;
            }

            set
            {
                productPrice = value;
            }
        }

        public int ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
            }
        }

        public int ComboId
        {
            get
            {
                return comboId;
            }

            set
            {
                comboId = value;
            }
        }
    }
}