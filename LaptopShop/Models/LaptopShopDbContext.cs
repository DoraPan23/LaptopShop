namespace LaptopShop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LaptopShopDbContext : DbContext
    {
        public LaptopShopDbContext()
            : base("name=LaptopShopDbContext")
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<Combo> Combo { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combo>()
                .Property(e => e.Product_List)
                .IsUnicode(false);

            modelBuilder.Entity<Combo>()
                .Property(e => e.totalMoney)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.address)
                .IsUnicode(false);
        }
    }
}
