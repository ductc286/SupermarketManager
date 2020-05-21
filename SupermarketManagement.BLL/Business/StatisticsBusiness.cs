using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.DataAccessLayer.IRepositories;
using SupermarketManagement.DataAccessLayer.Repositories;
using System;
using System.Data.Objects;
using System.Linq;

namespace SupermarketManagement.BLL.Business
{
    public class StatisticsBusiness : IStatisticsBusiness
    {
        IProductRepository _productRepository;
        ISaleBillRepository _saleBillRepository;
        IPurchaseBillRepository _purchaseBillRepository;

        public StatisticsBusiness()
        {
            _productRepository = new ProductRepository();
            _saleBillRepository = new SaleBillRepository();
            _purchaseBillRepository = new PurchaseBillRepository();
        }

        #region Products sale
        public int CountProductsSoldByInterval(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
        public int CountProducts()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SaleBill
        public int CountSaleBillByInterval(DateTime fromDate, DateTime toDate)
        {
            //var result = _saleBillRepository.GetAll().Where(s => fromDate.Subtract(s.CreatedDate).Days >= 0
            //&& toDate.Subtract(s.CreatedDate).Days <= 0).Count();

            var result = _saleBillRepository.GetAll().Where(s => EntityFunctions.DiffDays(fromDate, s.CreatedDate) >= 0
            && EntityFunctions.DiffDays(toDate, s.CreatedDate) <= 0).Count();

            return result;
        }
        public int GetSaleBillByInterval(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region PurchaseBill
        public int CountPurchaseBillByInterval(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
        public int GetPurchaseBillInterval(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
