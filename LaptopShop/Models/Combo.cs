namespace LaptopShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Combo")]
    public partial class Combo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Combo_Name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Product_List { get; set; }

        [Column(TypeName = "date")]
        public DateTime startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime endDate { get; set; }

        public double totalMoney { get; set; }

        public int discount { get; set; }

        public string Image { get; set; }
    }
}
