using System;
using System.ComponentModel.DataAnnotations;

namespace SupermarketManagement.Core.Models
{
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

        public virtual Staff Staff { get; set; }
    }
}
