namespace LaptopShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
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

        [Column(TypeName = "text")]
        [Required]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime joinDate { get; set; }

        public int Role_ID { get; set; }
    }
}
