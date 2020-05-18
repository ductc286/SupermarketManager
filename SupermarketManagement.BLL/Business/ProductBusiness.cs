using Supermarketmanagement.Core.ViewModels;
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

        public bool Add(ProductViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var product = new Product()
            {
                ProductName = entity.ProductName,
                CategoryId = entity.CategoryId,
                SupplierId = entity.SupplierId,
                Serial = entity.Serial,
                Price = entity.Price,
                Unit = entity.Unit,
                Note = entity.Note
            };

            return _productRepository.Add(product);
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public Supplier GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var foundProduct = _productRepository.GetById(entity.ProductId);
            if (foundProduct == null)
            {
                return false;
            }
            foundProduct.ProductName = entity.ProductName;
            foundProduct.Serial = entity.Serial;
            foundProduct.SupplierId = entity.SupplierId;
            foundProduct.CategoryId = entity.CategoryId;
            foundProduct.Price = entity.Price;
            foundProduct.Sold = entity.Sold;
            foundProduct.Inventory = entity.Inventory;
            foundProduct.Unit = entity.Unit;
            foundProduct.IsActive = entity.IsActive;
            foundProduct.Note = entity.Note;

            return _productRepository.Update(foundProduct);
        }
    }
}
