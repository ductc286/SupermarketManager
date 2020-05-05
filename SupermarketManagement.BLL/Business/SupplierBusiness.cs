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
        public SupplierBusiness()
        {
            _supplierRepository = new SupplierRepository();
        }

        public bool Add(Supplier entity)
        {
            return _supplierRepository.Add(entity);
        }

        public bool Delete(object id)
        {
            var entity = _supplierRepository.GetById(id);
            if (entity == null)
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

        public bool Update(Supplier entity)
        {
            return _supplierRepository.Update(entity);
        }
    }
}
