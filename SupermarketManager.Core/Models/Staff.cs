using System;
using System.ComponentModel.DataAnnotations;

namespace SupermarketManager.Core.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Account { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }

    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(255)]
        public string SupplierName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }


    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Serial { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public int Price { get; set; }

        public int Sold { get; set; } = 0;

        public int Inventory { get; set; } = 0;

        [Required]
        [MaxLength(255)]
        public string Unit { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(255)]
        public string Note { get; set; }
    }

    public class PurchaseBill
    {
        [Key]
        [MaxLength(30)]
        public string PurchaseBillId { get; set; }

        public int SupplierId { get; set; }

        [Range(0,100)]
        public byte Discount { get; set; }

        [Range(0, 100)]
        public byte VAT { get; set; }

        public long TotalMoney { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StaffId { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }

    public class PurchaseBillDetail
    {
        [Key]
        [MaxLength(255)]
        public string Id { get; set; }

        public int PurchaseBillId { get; set; }

        public int ProductId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        public int Price { get; set; }

        public long TotalMoney { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }

    public class SaleBill
    {
        [Key]
        [MaxLength(30)]
        public string SaleBillId { get; set; }

        [Range(0, 100)]
        public byte Discount { get; set; }

        public long TotalMoney { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StaffId { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }

    public class SaleBillDetail
    {
        [Key]
        [MaxLength(255)]
        public string Id { get; set; }

        public int SaleBillId { get; set; }

        public int ProductId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        public int Price { get; set; }

        public long TotalMoney { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }

    public class EndOfShift
    {
        [Key]
        public int EndOfShiftId { get; set; }

        public int StaffId { get; set; }

        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime From { get; set; }

        [DataType(DataType.Time)]
        public DateTime To { get; set; }

        public byte TotalHours { get; set; }

        public bool IsApproved { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }
}
