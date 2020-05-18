using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface ISupplierBusiness
    {
        Supplier GetById(object id);
        List<Supplier> GetAll();
        bool Delete(object id);
        bool Add(SupplierViewModel entity);
        bool Update(SupplierViewModel entity);
    }
}
