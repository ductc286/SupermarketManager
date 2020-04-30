using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketManagement.Core.Models
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

        public int StaffRole { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual ICollection<SaleBill> SaleBills { get; set; }
        public virtual ICollection<PurchaseBill> PurchaseBills { get; set; }
        public virtual ICollection<EndOfShift> EndOfShifts { get; set; }
    }
}
