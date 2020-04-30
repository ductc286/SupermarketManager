using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketManagement.Core.Models
{
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

        public virtual ICollection<PurchaseBillDetail> PurchaseBillDetails { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
