using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketManagement.Core.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
