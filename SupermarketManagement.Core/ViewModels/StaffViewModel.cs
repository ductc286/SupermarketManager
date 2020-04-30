using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarketmanagement.Core.ViewModels
{
    public class StaffViewModel
    {
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

        public DateTime CreatedDate { get; set; }

        public int StaffRole { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }
}
