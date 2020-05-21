using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;

namespace SupermarketManagement.BLL.IBusiness
{

    public interface IEndOfShiftBusiness
    {
        List<EndOfShift> GetAll();
        bool Delete(EndOfShift entity);
        bool Add(EndOfShiftViewModel entity);

        void Approve(EndOfShift entity);
        bool Update(EndOfShiftViewModel entity);
    }
}
