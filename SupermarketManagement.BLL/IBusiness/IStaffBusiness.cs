using Supermarketmanagement.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface IStaffBusiness
    {
        CurrentStaffViewModel GetStaffViewModel(LoginStaffViewModel loginStaffViewModel);
    }
}
