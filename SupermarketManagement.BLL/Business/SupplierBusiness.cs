using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using SupermarketManagement.DataAccessLayer.IRepositories;
using SupermarketManagement.DataAccessLayer.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketManagement.BLL.Business
{
    /// <summary>
    /// Logical processing, interacting with views and models, the main object is Supplier
    /// </summary>
    public class SupplierBusiness : ISupplierBusiness
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseBillBusiness _purchaseBillBusiness;
        public SupplierBusiness()
        {
            _supplierRepository = new SupplierRepository();
            _productRepository = new ProductRepository();
            _purchaseBillBusiness = new PurchaseBillBusiness();
        }

        public bool Add(SupplierViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var supplier = new Supplier()
            {
                SupplierName = entity.SupplierName,
                Description = entity.Description
            };

            return _supplierRepository.Add(supplier);
        }

        public bool Delete(object id)
        {
            var entity = _supplierRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }
            if (_productRepository.GetAll().Any(p => p.SupplierId == entity.SupplierId)
                || _purchaseBillBusiness.GetAll().Any(p => p.SupplierId == entity.SupplierId))
            {
                return false;
            }
            return _supplierRepository.Delete(entity);
        }


        public Supplier GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll().ToList();
        }

        public bool Update(SupplierViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var foundSupplier = _supplierRepository.GetById(entity.SupplierId);
            if (foundSupplier == null)
            {
                return false;
            }
            foundSupplier.SupplierName = entity.SupplierName;
            foundSupplier.Description = entity.Description;
            return _supplierRepository.Update(foundSupplier);
        }
    }
}
