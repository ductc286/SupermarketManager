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
    public class SaleBillBusiness : ISaleBillBusiness
    {
        private readonly ISaleBillRepository _saleBillRepository;
        private readonly ISaleBillDetailRepository _saleBillDetailRepository;
        public SaleBillBusiness()
        {
            _saleBillRepository = new SaleBillRepository();
            _saleBillDetailRepository = new SaleBillDetailRepository();
        }

        public bool Add(SaleBillViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var saleBill = entity.MapToSaleBill();
            saleBill.SaleBillId = IdUtilities.GenerateByTimeSpan();
            saleBill.CreatedDate = DateTime.Now;
            saleBill.StaffId = StaffGlobal.CurrentStaff.StaffId;
            _saleBillRepository.Add(saleBill);
            foreach (var item in entity.SaleBillDetailViewModels)
            {
                var saleBillDetail = item.MapToSaleBillDetail();
                saleBillDetail.SaleBillId = saleBill.SaleBillId;
                _saleBillDetailRepository.Add(saleBillDetail);
            }
                return true;
        }

        public bool Delete(object id)
        {
            var saleBill = _saleBillRepository.GetById(id);
            if (saleBill == null)
            {
                return false;
            }

            _saleBillRepository.Delete(saleBill);
            _saleBillDetailRepository.DeleteRange(saleBill.SaleBillDetails);
            
            return true;
        }

        public List<SaleBill> GetAll()
        {
            if (StaffGlobal.CurrentStaff == null)
            {
                return null;
            }
            else if (StaffGlobal.CurrentStaff.StaffRole == (int)StaffRole.Administrator)
            {
                return _saleBillRepository.GetAll().ToList();
            }
            else
            {
                return _saleBillRepository.FindAll(s => s.StaffId == StaffGlobal.CurrentStaff.StaffId).ToList();
            }
        }

        public SaleBill GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(SaleBillViewModel entity)
        {

            var saleBill = entity.MapToSaleBill();
            var newSaleBillDetails = new List<SaleBillDetail>();
            foreach (var item in entity.SaleBillDetailViewModels)
            {
                var purchaseBillDetail = item.MapToSaleBillDetail();
                purchaseBillDetail.SaleBillId = saleBill.SaleBillId;
                newSaleBillDetails.Add(purchaseBillDetail);
            }
            _saleBillRepository.Update(saleBill);
            var oldSaleBillDetails = _saleBillDetailRepository.FindAll(pd => pd.SaleBillId == entity.SaleBillId);
            if (oldSaleBillDetails != null)
            {
                var deleteSaleBillDetails = oldSaleBillDetails.Where(op => !newSaleBillDetails.Any(p => p.Id == op.Id));
                var addSaleBillDetails = newSaleBillDetails.Where(p => !oldSaleBillDetails.Any(op => op.Id == p.Id));
                var updateSaleBillDetails = newSaleBillDetails.Where(p => oldSaleBillDetails.Any(op => op.Id == p.Id));
                _saleBillDetailRepository.DeleteRange(deleteSaleBillDetails);
                _saleBillDetailRepository.AddRange(addSaleBillDetails);
                _saleBillDetailRepository.UpdateRange(updateSaleBillDetails);

            }
            return true;
        }
    }
}
