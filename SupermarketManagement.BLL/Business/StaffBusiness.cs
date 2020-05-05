using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.DataAccessLayer.IRepositories;
using SupermarketManagement.DataAccessLayer.Repositories;

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

    }
}
