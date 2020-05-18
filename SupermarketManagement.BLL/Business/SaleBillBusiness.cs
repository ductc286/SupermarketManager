using Supermarketmanagement.Core.Common;
using Supermarketmanagement.Core.Utilities;
using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using SupermarketManagement.DataAccessLayer.IRepositories;
using SupermarketManagement.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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
                saleBillDetail.SaleBillId = entity.SaleBillId;
                _saleBillDetailRepository.Add(saleBillDetail);
            }
            return true;
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public List<SaleBill> GetAll()
        {
            throw new NotImplementedException();
        }

        public SaleBill GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(SaleBillViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
