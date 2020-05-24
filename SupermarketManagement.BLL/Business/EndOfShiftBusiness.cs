using Supermarketmanagement.Core.Common;
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
    public class EndOfShiftBusiness : IEndOfShiftBusiness
    {
        IEndOfShiftRepository _endOfShiftRepository;
        ISaleBillRepository _saleBillRepository;
        public EndOfShiftBusiness()
        {
            _endOfShiftRepository = new EndOfShiftRepository();
            _saleBillRepository = new SaleBillRepository();
        }
        public bool Add(EndOfShiftViewModel entity)
        {
            var endOfShift = entity.MapToEndOfShift();
            endOfShift.CreatedDate = DateTime.Now;
            endOfShift.StaffId = StaffGlobal.CurrentStaff.StaffId;
            DateTime fromDatetime = new DateTime(endOfShift.CreatedDate.Year, endOfShift.CreatedDate.Month, endOfShift.CreatedDate.Day, entity.From, 0, 0);
            DateTime toDatetime = new DateTime(endOfShift.CreatedDate.Year, endOfShift.CreatedDate.Month, endOfShift.CreatedDate.Day, entity.To, 0, 0);
            //hanlder money
            long totalMoney = 0;
            try
            {
                totalMoney = _saleBillRepository.GetAll().Where(s => !s.IsAprroved && s.StaffId == endOfShift.StaffId
                    && s.CreatedDate >= fromDatetime && s.CreatedDate <= toDatetime)
                    .Sum(s => s.TotalMoney);
            }
            catch (Exception)
            {
            }
            endOfShift.TotalMoney = totalMoney;
            return _endOfShiftRepository.Add(endOfShift);
        }

        public void Approve(EndOfShift oldEntity)
        {
            var entity = _endOfShiftRepository.GetById(oldEntity.EndOfShiftId);
            if (entity == null)
            {
                return;
            }
            entity.IsApproved = true;
            _endOfShiftRepository.Update(entity);
            DateTime fromDatetime = new DateTime(entity.CreatedDate.Year, entity.CreatedDate.Month, entity.CreatedDate.Day, entity.From, 0, 0);
            DateTime toDatetime = new DateTime(entity.CreatedDate.Year, entity.CreatedDate.Month, entity.CreatedDate.Day, entity.To, 0, 0);

            var listSaleBill = _saleBillRepository.GetAll().Where(s => !s.IsAprroved
                && s.CreatedDate >= fromDatetime && s.CreatedDate <= toDatetime);
            foreach (var item in listSaleBill)
            {
                item.IsAprroved = true;
                _saleBillRepository.Update(item);
            }
        }

        public bool Delete(EndOfShift entity)
        {
            return _endOfShiftRepository.Delete(entity);

        }

        public List<EndOfShift> GetAll()
        {
            if (StaffGlobal.CurrentStaff.StaffRole == (int)StaffRole.Administrator)
            {
                return _endOfShiftRepository.GetAll().OrderByDescending(e => e.CreatedDate).ToList();
            }
            var staffId = StaffGlobal.CurrentStaff.StaffId;
            return _endOfShiftRepository.FindAll(e => e.StaffId == staffId).OrderByDescending(e => e.CreatedDate).ToList();
        }

        public bool Update(EndOfShiftViewModel entity)
        {
            var endOfShift = entity.MapToEndOfShift();
            endOfShift.CreatedDate = DateTime.Now;
            endOfShift.EndOfShiftId = StaffGlobal.CurrentStaff.StaffId;
            DateTime fromDatetime = new DateTime(endOfShift.CreatedDate.Year, endOfShift.CreatedDate.Month, endOfShift.CreatedDate.Day, entity.From, 0, 0);
            DateTime toDatetime = new DateTime(endOfShift.CreatedDate.Year, endOfShift.CreatedDate.Month, endOfShift.CreatedDate.Day, entity.To, 0, 0);
            //hanlder money
            var totalMoney = _saleBillRepository.GetAll().Where(s => !s.IsAprroved
                && s.CreatedDate >= fromDatetime && s.CreatedDate <= toDatetime)
                .Sum(s => s.TotalMoney);
            endOfShift.TotalMoney = totalMoney;
            return _endOfShiftRepository.Update(endOfShift);
        }
    }
}
