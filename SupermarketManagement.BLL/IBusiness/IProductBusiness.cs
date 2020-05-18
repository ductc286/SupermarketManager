using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface IProductBusiness
    {
        Supplier GetById(object id);
        List<Product> GetAll();
        bool Delete(object id);
        bool Add(ProductViewModel entity);
        bool Update(ProductViewModel entity);
    }
}
