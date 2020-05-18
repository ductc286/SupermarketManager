using Supermarketmanagement.Core.Common;
using Supermarketmanagement.Core.Utilities;
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
    public class PurchaseBillBusiness : IPurchaseBillBusiness
    {
        private readonly IPurchaseBillRepository _purchaseBillRepository;
        private readonly IPurchaseBillDetailRepository _purchaseBillDetailRepository;
        public PurchaseBillBusiness()
        {
            _purchaseBillRepository = new PurchaseBillRepository();
            _purchaseBillDetailRepository = new PurchaseBillDetailRepository();
        }
        public bool Add(PurchaseBillViewModel entity)
        {
            var purchaseBill = entity.MapToPuchaseBill();
            purchaseBill.PurchaseBillId = IdUtilities.GenerateByTimeSpan();
            purchaseBill.CreatedDate = DateTime.Now;
            purchaseBill.StaffId = StaffGlobal.StaffId;
            _purchaseBillRepository.Add(purchaseBill);

            //purchaseBill.PurchaseBillDetails = new List<PurchaseBillDetail>();
            //var purchaseBillDetails = new List<PurchaseBillDetail>();
            foreach (var item in entity.PurchaseBillDetailViewModels)
            {
                var purchaseBillDetail = item.MapToPurchaseBillDetail();
                _purchaseBillDetailRepository.Add(purchaseBillDetail);
            }
            
            return true;
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseBill> GetAll()
        {
            return _purchaseBillRepository.GetAll().ToList();
        }

        public PurchaseBill GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(PurchaseBillViewModel entity)
        {
            var purchaseBill = entity.MapToPuchaseBill();
            var newPurchaseBillDetails = new List<PurchaseBillDetail>();
            foreach (var item in entity.PurchaseBillDetailViewModels)
            {
                var purchaseBillDetail = item.MapToPurchaseBillDetail();
                purchaseBillDetail.PurchaseBillId = purchaseBill.PurchaseBillId;
                newPurchaseBillDetails.Add(purchaseBillDetail);
            }
            _purchaseBillRepository.Update(purchaseBill);
            var oldPurchaseBillDetails = _purchaseBillDetailRepository.FindAll(pd => pd.PurchaseBillId == entity.PurchaseBillId).ToList();
            if (oldPurchaseBillDetails != null)
            {
                var deletePurchaseBillDetails = oldPurchaseBillDetails.Where(op => !newPurchaseBillDetails.Any(p => p.Id == op.Id));
                var addPurchaseBillDetails = newPurchaseBillDetails.Where(p => !oldPurchaseBillDetails.Any(op => op.Id == p.Id));
                var updatePurchaseBillDetails = newPurchaseBillDetails.Where(p => oldPurchaseBillDetails.Any(op => op.Id == p.Id));
                _purchaseBillDetailRepository.DeleteRange(deletePurchaseBillDetails);
                _purchaseBillDetailRepository.AddRange(addPurchaseBillDetails);
                _purchaseBillDetailRepository.UpdateRange(updatePurchaseBillDetails);

            }
            return true;
        }
    }
}
