namespace LaptopShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(80)]
        public string Product_Name { get; set; }

        public int Catalog_ID { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "text")]
        public string Image { get; set; }

        public decimal? Discount { get; set; }

        public decimal? DiscountMoney { get; set; }

        [StringLength(600)]
        public string Detail { get; set; }

        public int? Brand_ID { get; set; }
    }
}
