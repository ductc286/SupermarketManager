using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using SupermarketManagement.DataAccessLayer.IRepositories;
using SupermarketManagement.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketManagement.BLL.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;
        public ProductBusiness()
        {
            _productRepository = new ProductRepository();
        }
        public List<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }
    }
}
