namespace LaptopShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public double? Total_Price { get; set; }

        public int? User_Id { get; set; }

        public int? Status { get; set; }
    }
}
