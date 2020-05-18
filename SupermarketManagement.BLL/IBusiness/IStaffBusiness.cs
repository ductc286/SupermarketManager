using Supermarketmanagement.Core.ViewModels;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface IStaffBusiness
    {
        CurrentStaffViewModel GetStaffViewModel(LoginStaffViewModel loginStaffViewModel);
    }
}
