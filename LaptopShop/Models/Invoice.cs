namespace LaptopShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        public int ID { get; set; }

        public int Customer_ID { get; set; }

        public int? Employee_ID { get; set; }

        public decimal totalMoney { get; set; }

        [Column(TypeName = "date")]
        public DateTime createdDate { get; set; }

        [Required]
        [StringLength(100)]
        public string customerAddress { get; set; }
    }
}
