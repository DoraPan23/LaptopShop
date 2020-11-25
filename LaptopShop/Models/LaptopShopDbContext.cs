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

        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<Combo> Combo { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDetail> ProductDetail { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combo>()
                .Property(e => e.Product_List)
                .IsUnicode(false);

            modelBuilder.Entity<Combo>()
                .Property(e => e.totalMoney)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Combo>()
                .Property(e => e.discountMoney)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Customer>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.totalMoney)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Discount)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.DiscountMoney)
                .HasPrecision(10, 0);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.Price)
                .HasPrecision(10, 0);
        }
    }
}
