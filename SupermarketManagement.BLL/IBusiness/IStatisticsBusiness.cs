using System;

namespace SupermarketManagement.BLL.IBusiness
{
    public interface IStatisticsBusiness
    {
        #region Products sale
        int CountProductsSoldByInterval(DateTime fromDate, DateTime toDate);
        int CountProducts();

        #endregion

        #region SaleBill
        int CountSaleBillByInterval(DateTime fromDate, DateTime toDate);
        int GetSaleBillByInterval(DateTime fromDate, DateTime toDate);
        #endregion

        #region PurchaseBill
        int CountPurchaseBillByInterval(DateTime fromDate, DateTime toDate);
        int GetPurchaseBillInterval(DateTime fromDate, DateTime toDate);
        #endregion
    }
}
