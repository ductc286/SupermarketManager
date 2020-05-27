using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface IStaffBusiness
    {
        CurrentStaffViewModel GetStaffViewModel(LoginStaffViewModel loginStaffViewModel);

        bool Add(StaffViewModel entity);
        bool Update(StaffViewModel entity);
        List<Staff> GetAll();
        bool ChangePassword(ChangePasswordViewModel changePasswordViewModel);
    }
}
