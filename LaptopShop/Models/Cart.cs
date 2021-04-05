namespace LaptopShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int ID { get; set; }

        public int? Product_Id { get; set; }

        public int? Quantity { get; set; }

        public int? Combo_Id { get; set; }

        public int? User_Id { get; set; }
    }
}
