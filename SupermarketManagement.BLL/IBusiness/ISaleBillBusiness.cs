using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface ISaleBillBusiness
    {
        SaleBill GetById(object id);
        List<SaleBill> GetAll();
        bool Delete(object id);
        bool Add(SaleBillViewModel entity);
        bool Update(SaleBillViewModel entity);
    }
}
