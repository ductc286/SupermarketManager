using SupermarketManagement.Core.Models;
using System.Collections.Generic;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface IProductBusiness
    {
        List<Product> GetAll();
    }
}
