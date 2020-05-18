using System.ComponentModel.DataAnnotations;

namespace Supermarketmanagement.Core.ViewModels
{
    public class SupplierViewModel : BaseViewModel
    {
        [Key]
        public int SupplierId { get; set; }

        private string _supplierName;
        [Required (ErrorMessage ="Vui Lòng nhập tên nhà phân phối.")]
        [MaxLength(255, ErrorMessage = "Tên nhà phân phối có độ dài tối đa là {1}")]
        public string SupplierName {
            get { return _supplierName; }
            set
            {
                OnPropertyChanged(ref _supplierName, value);
            }
        }

        private string _description;
        [MaxLength(255, ErrorMessage = "Miêu tả có độ dài tối đa là {1}")]
        public string Description {
            get { return _description; }
            set
            {
                OnPropertyChanged(ref _description, value);
            }
        }

        
    }
}
