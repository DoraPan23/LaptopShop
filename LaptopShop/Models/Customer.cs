namespace LaptopShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(20)]
        public string lastName { get; set; }

        public bool gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthDate { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime joinDate { get; set; }
    }
}
