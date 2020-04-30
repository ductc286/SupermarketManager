using SupermarketManagement.Core.Models;
using System.Data.Entity;

namespace SupermarketManagement.DataAccessLayer.DatabaseContext
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("MyConnectionString")
        {
            Database.SetInitializer<MyDBContext>(new MyInitializer());

        }

        //// Set DBset in here
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseBill> PurchaseBills { get; set; }
        public DbSet<PurchaseBillDetail> PurchaseBillDetails { get; set; }
        public DbSet<SaleBill> SaleBills { get; set; }
        public DbSet<SaleBillDetail> SaleBillDetails { get; set; }
        public DbSet<EndOfShift> EndOfShifts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
