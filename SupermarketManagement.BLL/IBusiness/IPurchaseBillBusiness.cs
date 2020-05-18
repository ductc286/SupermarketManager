using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface IPurchaseBillBusiness
    {
        PurchaseBill GetById(object id);
        List<PurchaseBill> GetAll();
        bool Delete(object id);
        bool Add(PurchaseBillViewModel entity);
        bool Update(PurchaseBillViewModel entity);
    }
}
