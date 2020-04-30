using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.DataAccessLayer.IRepositories;
using SupermarketManagement.DataAccessLayer.Repositories;

namespace SupermarketManagement.BLL.Business
{
    public class StaffBusiness : IStaffBusiness
    {
        private readonly IStaffRepository _staffRepository;
        public StaffBusiness()
        {
            _staffRepository = new StaffRepository();
        }

        public StaffViewModel GetStaffViewModel(LoginStaffViewModel loginStaffViewModel)
        {
            var staff = _staffRepository.Find(filter: s => s.Account == loginStaffViewModel.Account && s.PasswordHash == loginStaffViewModel.Password);
            //StaffViewModel staffViewModel = Mapper.Map<StaffViewModel>(staff);
            if (staff == null)
            {
                return null;
            }
            var staffViewModel = new StaffViewModel()
            {
                StaffId = staff.StaffId,
                Account = staff.Account,
                FullName = staff.FullName,
                Email = staff.Email,
                CreatedDate = staff.CreatedDate,
                Note = staff.Note,
                IsActive = staff.IsActive,
                PhoneNumber = staff.PhoneNumber,
                StaffRole = staff.StaffRole
            };
            return staffViewModel;
        }

    }
}
