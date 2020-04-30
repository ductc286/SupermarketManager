using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarketmanagement.Core.ViewModels
{
    public class LoginStaffViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
