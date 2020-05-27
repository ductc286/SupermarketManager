using Supermarketmanagement.Core.Common;
using Supermarketmanagement.Core.Utilities;
using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using SupermarketManagement.DataAccessLayer.IRepositories;
using SupermarketManagement.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketManagement.BLL.Business
{
    /// <summary>
    /// Logical processing, interacting with views and models, the main object is Staff
    /// </summary>
    public class StaffBusiness : IStaffBusiness
    {
        private readonly IStaffRepository _staffRepository;
        public StaffBusiness()
        {
            _staffRepository = new StaffRepository();
        }

        public bool Add(StaffViewModel entity)
        {
            var staff = entity.MapToStaff();
            staff.PasswordHash = EncodeUtilities.GetPasswordHash(entity.Password);
            staff.CreatedDate = DateTime.Now;
            staff.FullName = EncodeUtilities.StringNormalize(entity.FullName);
            staff.Account = GenerateAccount(entity.FullName);
            return _staffRepository.Add(staff);
        }
        public bool Update(StaffViewModel entity)
        {
            var staff = entity.MapToStaff();
            staff.PasswordHash = EncodeUtilities.GetPasswordHash(entity.Password);
            staff.FullName = EncodeUtilities.StringNormalize(entity.FullName);
            return _staffRepository.Update(staff);
        }

        public bool ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            var staff = _staffRepository.GetById(StaffGlobal.CurrentStaff.StaffId);
            if (staff != null && staff.PasswordHash == EncodeUtilities.GetPasswordHash(changePasswordViewModel.Password))
            {
                staff.PasswordHash = EncodeUtilities.GetPasswordHash(changePasswordViewModel.NewPassword);
                _staffRepository.Update(staff);
                return true;
            }
            return false;
        }

        public CurrentStaffViewModel GetStaffViewModel(LoginStaffViewModel loginStaffViewModel)
        {
            var staff = _staffRepository.Find(filter: s => s.Account == loginStaffViewModel.Account && s.PasswordHash == loginStaffViewModel.Password);
            //StaffViewModel staffViewModel = Mapper.Map<StaffViewModel>(staff);
            if (staff == null)
            {
                return null;
            }
            var staffViewModel = new CurrentStaffViewModel()
            {
                StaffId = staff.StaffId,
                Account = staff.Account,
                StaffRole = staff.StaffRole
            };
            return staffViewModel;
        }

        public List<Staff> GetAll()
        {
            return _staffRepository.GetAll().OrderByDescending(s => s.CreatedDate).ToList();
        }

        private string GenerateAccount(string fullName)
        {
            string fullNameNormalize = EncodeUtilities.StringNormalize(fullName);
            fullNameNormalize = EncodeUtilities.Utf8Convert(fullNameNormalize);
            string account = GetAccountFromFullName(fullNameNormalize);
            var foundStaff = _staffRepository.Find(s => s.Account.ToLower() == account.ToLower());
            int i = 1;
            string result = account;
            while (foundStaff != null)
            {
                result = account + i;
                foundStaff = _staffRepository.Find(s => s.Account.ToLower() == result.ToLower());
                i++;
            }

            return result;
        }

        private string GetAccountFromFullName(string fullNameNormalize)
        {
            string[] arrNameElement = fullNameNormalize.Split(' ');
            var length = arrNameElement.Length;
            string account = arrNameElement[length-1];
            if (length <= 1)
            {
                return account;
            }
            for (int i = 0; i < length-1; i++)
            {
                account += arrNameElement[i].Substring(0, 1);
            }
            return account;
        }
    }
}
