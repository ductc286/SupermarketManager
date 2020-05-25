﻿using Supermarketmanagement.Core.ViewModels;
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

        #region Sale
        public int CountSaleBillByInterval(DateTime fromDate, DateTime toDate)
        {
            var count = 0;
            count = _saleBillRepository.GetAll().Where(s =>
            (s.CreatedDate.Year > fromDate.Year
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month > fromDate.Month
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month == fromDate.Month && s.CreatedDate.Day >= fromDate.Day))
             ) &&
             (s.CreatedDate.Year < toDate.Year
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month < toDate.Month
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month == toDate.Month && s.CreatedDate.Day <= toDate.Day))
             )).Count();
            return count;
        }

        public long CountSaleMoneyByInterval(DateTime fromDate, DateTime toDate)
        {
            long sum = 0;
            try
            {
                sum = _saleBillRepository.GetAll().Where(s =>
             (s.CreatedDate.Year > fromDate.Year
                 || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month > fromDate.Month)
                 || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month == fromDate.Month && s.CreatedDate.Day >= fromDate.Day)
              ) &&
              (s.CreatedDate.Year < toDate.Year
                 || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month < toDate.Month)
                 || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month == toDate.Month && s.CreatedDate.Day <= toDate.Day)
              )).Sum(p => p.TotalMoney);
            }
            catch (Exception)
            {
                //throw;
            }
            return sum;
        }

        public long CountProductsSoldByInterval(DateTime fromDate, DateTime toDate)
        {
            long sum = 0;
            try
            {
                sum = _saleBillRepository.GetAll().Where(s =>
            (s.CreatedDate.Year > fromDate.Year
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month > fromDate.Month
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month == fromDate.Month && s.CreatedDate.Day >= fromDate.Day))
             ) &&
             (s.CreatedDate.Year < toDate.Year
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month < toDate.Month
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month == toDate.Month && s.CreatedDate.Day <= toDate.Day))
             )).Sum(p => p.SaleBillDetails.Sum(pd => (long)pd.Quantity));
            }
            catch (Exception)
            {
            }
            return sum;
        }
        #endregion

        #region Purchase
        public long CountProductsPurchasedByInterval(DateTime fromDate, DateTime toDate)
        {
            long sum = 0;
            try
            {
                sum = _purchaseBillRepository.GetAll().Where(s =>
            (s.CreatedDate.Year > fromDate.Year
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month > fromDate.Month
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month == fromDate.Month && s.CreatedDate.Day >= fromDate.Day))
             ) &&
             (s.CreatedDate.Year < toDate.Year
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month < toDate.Month
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month == toDate.Month && s.CreatedDate.Day <= toDate.Day))
             )).Sum(p => p.PurchaseBillDetails.Sum(pd => (long)pd.Quantity));
            }
            catch (Exception)
            {

                //throw;
            }
            return sum;
        }

        public int CountPurchaseBillByInterval(DateTime fromDate, DateTime toDate)
        {
            var count = 0;
            count = _purchaseBillRepository.GetAll().Where(s =>
            (s.CreatedDate.Year > fromDate.Year
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month > fromDate.Month
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month == fromDate.Month && s.CreatedDate.Day >= fromDate.Day))
             ) &&
             (s.CreatedDate.Year < toDate.Year
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month < toDate.Month
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month == toDate.Month && s.CreatedDate.Day <= toDate.Day))
             )).Count();
            return count;
        }

        public long CountPurchaseMoneyByInterval(DateTime fromDate, DateTime toDate)
        {
            long sum = 0;
            try
            {
                sum = _purchaseBillRepository.GetAll().Where(s =>
            (s.CreatedDate.Year > fromDate.Year
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month > fromDate.Month)
                || (s.CreatedDate.Year == fromDate.Year && s.CreatedDate.Month == fromDate.Month && s.CreatedDate.Day >= fromDate.Day)
             ) &&
             (s.CreatedDate.Year < toDate.Year
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month < toDate.Month)
                || (s.CreatedDate.Year == toDate.Year && s.CreatedDate.Month == toDate.Month && s.CreatedDate.Day <= toDate.Day)
             )).Sum(p => p.TotalMoney);
            }
            catch (Exception)
            {

                //throw;
            }
            return sum;
        }

        #endregion

        public StatisticsViewModel GetStatisticsViewModel(DateTime fromDate, DateTime toDate)
        {
            StatisticsViewModel statisticsViewModel = new StatisticsViewModel();
            statisticsViewModel.TotalSaleBill = CountSaleBillByInterval(fromDate, toDate);
            statisticsViewModel.TotalProductsSold = CountProductsSoldByInterval(fromDate, toDate);
            statisticsViewModel.TotalSalesMoney = CountSaleMoneyByInterval(fromDate, toDate);

            statisticsViewModel.TotalPurchaseBill = CountPurchaseBillByInterval(fromDate, toDate);
            statisticsViewModel.TotalProductsPurchased = CountProductsPurchasedByInterval(fromDate, toDate);
            statisticsViewModel.TotalPurchaseMoney = CountPurchaseMoneyByInterval(fromDate, toDate);

            return statisticsViewModel;
        }

        // not working
        private static bool IsInInterval(DateTime date, DateTime fromDate, DateTime toDate)
        {
            if ((date.Year > fromDate.Year
                    || (date.Year == fromDate.Year && date.Month > fromDate.Month
                    || (date.Year == fromDate.Year && date.Month == fromDate.Month && date.Day >= fromDate.Day)))
                &&
                 (date.Year < toDate.Year
                    || (date.Year == toDate.Year && date.Month < toDate.Month
                    || (date.Year == toDate.Year && date.Month == toDate.Month && date.Day <= fromDate.Day))
                 ))
            {
                return true;
            }
            return false;
        }
    }
}
