using SupermarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SupermarketManagement.DataAccessLayer.DatabaseContext
{
    public class MyInitializer : CreateDatabaseIfNotExists<MyDBContext>
    {
        protected override void Seed(MyDBContext context)
        {
            //// Seed data in here
            #region Component which sure is need for this system
            var staff = new Staff() {
                Account = "Admin",
                FullName = "Administrator",
                StaffRole = (int)StaffRole.Administrator,
                CreatedDate = DateTime.Now,
                PasswordHash = "234ksf"
            };
            context.Staffs.Add(staff);
            context.SaveChanges();
            #endregion

            #region Create sample data for the test version
            #region Add Suplier
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier()
                {
                    SupplierName = "Nhà cung cấp APk",
                    Description = "111 Mỹ Đình thôn, Hà Nội"
                },
                new Supplier()
                {
                    SupplierName = "Nhà cung cấp Kim Long",
                    Description = "141 Trung Kính, Hà Nội"
                },
                new Supplier()
                {
                    SupplierName = "Nhà cung cấp Linh Đan",
                    Description = "34 Thanh Xuân, Hà Nội"
                },
                new Supplier()
                {
                    SupplierName = "Nhà cung cấp Việt Nhật",
                    Description = "32 Ba Đình, Hà Nội"
                },
                new Supplier()
                {
                    SupplierName = "Nhà cung cấp Phiu phiu",
                    Description = "205 Mỹ Đình thôn, Hà Nội"
                },
            };
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            #endregion
            #region Add Categories
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    CategoryName = "Nước giải khát",
                    Description = "Gồm các loại nước uống Nước giải khát"
                },
                new Category()
                {
                    CategoryName = "Đồ ăn nhanh",
                    Description = "Gồm Đồ ăn ngọt "
                },
                new Category()
                {
                    CategoryName = "Đồ gia dụng",
                    Description = "Gồm Đồ gia dụng gia đình"
                },
                new Category()
                {
                    CategoryName = "Mỹ phẩm",
                    Description = "Gồm các Mỹ phẩm"
                },
                new Category()
                {
                    CategoryName = "Bánh kẹo",
                    Description = "Gồm Bánh kẹo"
                }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
            #endregion

            #region Add Product
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    CategoryId = categories[0].CategoryId,
                    Inventory = 50,
                    IsActive = true,
                    ProductName = "Nuớc cam",
                    Price = 10000,
                    Unit = "Chai",
                    SupplierId = suppliers[0].SupplierId
                },
                new Product()
                {
                    CategoryId = categories[0].CategoryId,
                    Inventory = 40,
                    IsActive = true,
                    ProductName = "Nuớc khoáng",
                    Price = 5000,
                    Unit = "Chai",
                    SupplierId = suppliers[0].SupplierId
                },
                new Product()
                {
                    CategoryId = categories[1].CategoryId,
                    Inventory = 13,
                    IsActive = true,
                    ProductName = "Thùng mì tôm Hảo Hảo 30 gói",
                    Price = 90000,
                    Unit = "Thùng",
                    SupplierId = suppliers[1].SupplierId
                },
                new Product()
                {
                    CategoryId = categories[1].CategoryId,
                    Inventory = 38,
                    IsActive = true,
                    ProductName = "Xúc xích phô mai",
                    Price = 13000,
                    Unit = "Túi",
                    SupplierId = suppliers[0].SupplierId
                },
                new Product()
                {
                    CategoryId = categories[2].CategoryId,
                    Inventory = 30,
                    IsActive = true,
                    ProductName = "Máy sấy tóc",
                    Price = 80000,
                    Unit = "Cái",
                    SupplierId = suppliers[3].SupplierId
                }
            };
            context.Products.AddRange(products);
            #endregion

            context.SaveChanges();
            #endregion
            base.Seed(context);
        }
    }
}