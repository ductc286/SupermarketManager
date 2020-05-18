using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System.Collections.Generic;

namespace SupermarketManagement.BLL.IBusiness
{

    public interface ICategoryBusiness
    {
        Category GetById(object id);
        List<Category> GetAll();
        bool Delete(object id);
        bool Add(CategoryViewModel entity);
        bool Update(CategoryViewModel entity);
    }
}
