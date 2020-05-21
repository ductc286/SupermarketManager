﻿using Supermarketmanagement.Core.Utilities;
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
            var staff = new Staff()
            {
                Account = "Admin",
                FullName = "Administrator",
                StaffRole = (int)StaffRole.Administrator,
                CreatedDate = DateTime.Now,
                PasswordHash = "matkhau123"
            };
            context.Staffs.Add(staff);
            context.SaveChanges();
            #endregion

            #region Create sample data for the test version
            #region Add Staff
            List<Staff> staffs = new List<Staff>()
            {
                new Staff()
                {
                    Account = "AnhLT",
                    Email = "anhlt@gmail.com",
                    CreatedDate = DateTime.Now,
                    FullName = "Lê Thị Ánh",
                    PasswordHash = "matkhau123",
                    StaffRole = (int)StaffRole.SaleStaff,
                    IsActive = true,
                    Note = "Đang là Sinh viên"
                },
                new Staff()
                {
                    Account = "LuongNT",
                    Email = "luongnt@gmail.com",
                    CreatedDate = DateTime.Now,
                    FullName = "Nguyễn Thị Lương",
                    PasswordHash = "matkhau123",
                    StaffRole = (int)StaffRole.SaleStaff,
                    IsActive = true,
                    Note = ""
                },
                new Staff()
                {
                    Account = "DoanTV",
                    Email = "doantv@gmail.com",
                    CreatedDate = DateTime.Now,
                    FullName = "Trương Văn Đoàn",
                    PasswordHash = "matkhau123",
                    StaffRole = (int)StaffRole.SaleStaff,
                    IsActive = true,
                    Note = ""
                },
                new Staff()
                {
                    Account = "HaiPM",
                    Email = "haipm@gmail.com",
                    CreatedDate = DateTime.Now,
                    FullName = "Phạm Văn Hải",
                    PasswordHash = "matkhau123",
                    StaffRole = (int)StaffRole.SaleStaff,
                    IsActive = true,
                    Note = ""
                },
                new Staff()
                {
                    Account = "LuongNT",
                    Email = "luongnt@gmail.com",
                    CreatedDate = DateTime.Now,
                    FullName = "Nguyễn Thị Lương",
                    PasswordHash = "matkhau123",
                    StaffRole = (int)StaffRole.SaleStaff,
                    IsActive = false,
                    Note = ""
                }
            };
            context.Staffs.AddRange(staffs);
            #endregion

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

            #region Add Products
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
                    Inventory = 40,
                    IsActive = true,
                    ProductName = "Xúc xích phô mai",
                    Price = 20000,
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
            context.SaveChanges();
            #endregion

            #region Add PurchaseBill
            List<PurchaseBill> purchaseBills = new List<PurchaseBill>() { };
            string billId;

            billId = "201168657";
            var item1 = new PurchaseBill()
            {

                PurchaseBillId = billId,
                StaffId = staffs[0].StaffId,
                Discount = 5,
                CreatedDate = DateTime.Now,
                SupplierId = suppliers[0].SupplierId,
                TotalMoney = 190000,
                PurchaseBillDetails = new List<PurchaseBillDetail>()
                    {
                        new PurchaseBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 20,
                            Price = products[0].Price,
                            PurchaseBillId = billId,
                            ProductId = products[0].ProductId,
                            TotalMoney = 190000
                        }
                    }
            };
            purchaseBills.Add(item1);

            billId = "201168687";
            var item2 = new PurchaseBill()
            {
                PurchaseBillId = billId,
                StaffId = staffs[0].StaffId,
                Discount = 5,
                CreatedDate = DateTime.Now,
                SupplierId = suppliers[1].SupplierId,
                TotalMoney = 71250,
                PurchaseBillDetails = new List<PurchaseBillDetail>()
                    {
                        new PurchaseBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 15,
                            Price = products[1].Price,
                            ProductId = products[1].ProductId,
                            TotalMoney = 71250,
                            PurchaseBillId = billId
                        }
                    }
            };
            purchaseBills.Add(item2);

            billId = "201138657";
            var item3 = new PurchaseBill()
            {
                PurchaseBillId = billId,
                StaffId = staffs[1].StaffId,
                Discount = 5,
                CreatedDate = DateTime.Now,
                SupplierId = suppliers[0].SupplierId,
                TotalMoney = 380000,
                PurchaseBillDetails = new List<PurchaseBillDetail>()
                    {
                        new PurchaseBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 20,
                            Price = products[3].Price,
                            ProductId = products[3].ProductId,
                            TotalMoney = 380000,
                            PurchaseBillId = billId
                        }
                    }
            };
            purchaseBills.Add(item3);

            billId = "201168639";
            var item4 = new PurchaseBill()
            {
                PurchaseBillId = billId,
                StaffId = staffs[0].StaffId,
                Discount = 5,
                CreatedDate = DateTime.Now,
                SupplierId = suppliers[0].SupplierId,
                TotalMoney = 332500,
                PurchaseBillDetails = new List<PurchaseBillDetail>()
                    {
                        new PurchaseBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 10,
                            Price = products[4].Price,
                            ProductId = products[4].ProductId,
                            TotalMoney = 190000,
                            PurchaseBillId = billId
                        },
                        new PurchaseBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 30,
                            Price = products[1].Price,
                            ProductId = products[1].ProductId,
                            TotalMoney = 142500,
                            PurchaseBillId = billId
                        }
                    }
            };
            purchaseBills.Add(item4);

            billId = "201168617";
            var item5 = new PurchaseBill()
            {
                PurchaseBillId = billId,
                StaffId = staffs[0].StaffId,
                Discount = 5,
                CreatedDate = DateTime.Now.AddDays(-2),
                SupplierId = suppliers[0].SupplierId,
                TotalMoney = 1805000,
                PurchaseBillDetails = new List<PurchaseBillDetail>()
                    {
                        new PurchaseBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 20,
                            Price = products[0].Price,
                            ProductId = products[0].ProductId,
                            TotalMoney = 190000 ,
                            PurchaseBillId = billId
                        },
                        new PurchaseBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 10,
                            Price = products[2].Price,
                            ProductId = products[2].ProductId,
                            TotalMoney = 855000 ,
                            PurchaseBillId = billId
                        },
                        new PurchaseBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 10,
                            Price = products[4].Price,
                            ProductId = products[4].ProductId,
                            TotalMoney = 760000 ,
                            PurchaseBillId = billId
                        }
                    }
            };
            purchaseBills.Add(item5);

            context.PurchaseBills.AddRange(purchaseBills);
            context.SaveChanges();
            #endregion

            #region Add SaleBill
            List<SaleBill> saleBills = new List<SaleBill>() { };

            billId = "201163657";
            var saleBill1 = new SaleBill()
            {
                SaleBillId = billId,
                StaffId = staffs[0].StaffId,
                Discount = 0,
                CreatedDate = DateTime.Now,
                IsAprroved = true,
                TotalMoney = 285000,
                SaleBillDetails = new List<SaleBillDetail>()
                    {
                        new SaleBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 30,
                            Price = products[0].Price,
                            SaleBillId = billId,
                            TotalMoney = 285000,
                            ProductId = products[0].ProductId
                        }
                    }
            };
            saleBills.Add(saleBill1);

            billId = "206163757";
            var saleBill2 = new SaleBill()
            {
                SaleBillId = billId,
                StaffId = staffs[0].StaffId,
                Discount = 0,
                CreatedDate = DateTime.Now,
                IsAprroved = true,
                TotalMoney = 25000,
                SaleBillDetails = new List<SaleBillDetail>()
                    {
                        new SaleBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 5,
                            Price = products[1].Price,
                            ProductId = products[1].ProductId,
                            TotalMoney = 25000,
                            SaleBillId = billId
                        }
                    }
            };
            saleBills.Add(saleBill2);

            billId = "203563657";
            var saleBill3 = new SaleBill()
            {
                SaleBillId = billId,
                StaffId = staffs[1].StaffId,
                Discount = 0,
                CreatedDate = DateTime.Now,
                IsAprroved = true,
                TotalMoney = 400000,
                SaleBillDetails = new List<SaleBillDetail>()
                    {
                        new SaleBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 20,
                            Price = products[3].Price,
                            ProductId = products[3].ProductId,
                            TotalMoney = 400000,
                            SaleBillId = billId
                        }
                    }
            };
            saleBills.Add(saleBill3);

            billId = "201103697";
            var saleBill4 = new SaleBill()
            {
                SaleBillId = billId,
                StaffId = staffs[0].StaffId,
                Discount = 0,
                CreatedDate = DateTime.Now,
                IsAprroved = true,
                TotalMoney = 85000,
                SaleBillDetails = new List<SaleBillDetail>()
                    {
                        new SaleBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 3,
                            Price = products[4].Price,
                            ProductId = products[4].ProductId,
                            TotalMoney = 60000,
                            SaleBillId = billId
                        },
                        new SaleBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 5,
                            Price = products[1].Price,
                            ProductId = products[1].ProductId,
                            TotalMoney = 25000,
                            SaleBillId = billId
                        }
                    }
            };
            saleBills.Add(saleBill4);

            billId = "201163907";
            var saleBill5 = new SaleBill()
            {
                SaleBillId = billId,
                StaffId = staffs[0].StaffId,
                Discount = 0,
                CreatedDate = DateTime.Now.AddDays(-2),
                IsAprroved = true,
                TotalMoney = 210000,
                SaleBillDetails = new List<SaleBillDetail>()
                    {
                        new SaleBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 4,
                            Price = products[0].Price,
                            ProductId = products[0].ProductId,
                            TotalMoney = 40000,
                            SaleBillId = billId
                        },
                        new SaleBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 1,
                            Price = products[2].Price,
                            ProductId = products[2].ProductId,
                            TotalMoney = 90000,
                            SaleBillId = billId
                        },
                        new SaleBillDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Quantity = 1,
                            Price = products[4].Price,
                            ProductId = products[4].ProductId,
                            TotalMoney = 80000,
                            SaleBillId = billId
                        }
                    }
            };
            saleBills.Add(saleBill5);

            context.SaleBills.AddRange(saleBills);
            #endregion

            context.SaveChanges();
            #endregion
            base.Seed(context);
        }
    }
}