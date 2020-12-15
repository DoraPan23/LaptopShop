namespace LaptopShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(20)]
        public string lastName { get; set; }

        public bool gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthDate { get; set; }

        [Column(TypeName = "text")]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? joinDate { get; set; }

        public bool isDisable { get; set; }

        public int Role_ID { get; set; }
    }
}
