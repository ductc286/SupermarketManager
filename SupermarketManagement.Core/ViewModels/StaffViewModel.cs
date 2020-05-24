using SupermarketManagement.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarketmanagement.Core.ViewModels
{
    public class StaffViewModel : BaseViewModel
    {
        public int StaffId { get; set; }

        private string _fullName;
        [Required]
        [MaxLength(150, ErrorMessage = "Tên có số kí tự tối đa là {1}")]
        public string FullName
        {
            get { return _fullName; }
            set
            {
                OnPropertyChanged(ref _fullName, value);
            }
        }

        private string _account;
        [Required]
        [MaxLength(30)]
        public string Account
        {
            get { return _account; }
            set
            {
                OnPropertyChanged(ref _account, value);
            }
        }


        private string _phoneNumber;
        [MaxLength(20, ErrorMessage = "Số điện thoại có số kí tự tối đa là {1}")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                OnPropertyChanged(ref _phoneNumber, value);
            }
        }


        private string _email;
        [MaxLength(255, ErrorMessage = "Email có số kí tự tối đa là {1}")]
        public string Email
        {
            get { return _email; }
            set
            {
                OnPropertyChanged(ref _email, value);
            }
        }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        private int _staffRole;
        [MaxLength(255, ErrorMessage = "Ghi chú có số kí tự tối đa là {1}")]
        public int StaffRole
        {
            get { return _staffRole; }
            set
            {
                OnPropertyChanged(ref _staffRole, value);
            }
        }
        private string _password;
        [MaxLength(255, ErrorMessage = "Mật khẩu có số kí tự tối đa là {1}")]
        public string Password
        {
            get { return _password; }
            set
            {
                OnPropertyChanged(ref _password, value);
            }
        }

        private string _note;
        [MaxLength(255, ErrorMessage = "Ghi chú có số kí tự tối đa là {1}")]
        public string Note
        {
            get { return _note; }
            set
            {
                OnPropertyChanged(ref _note, value);
            }
        }

        public Staff MapToStaff()
        {
            var staff = new Staff()
            {
                Account = this.Account,
                CreatedDate = this.CreatedDate,
                Email = this.Email,
                FullName = this.FullName,
                IsActive = this.IsActive,
                PhoneNumber = this.PhoneNumber,
                Note = this.Note,
                StaffId = this.StaffId,
                StaffRole = this.StaffRole,
            };
            return staff;
        }
    }
}
