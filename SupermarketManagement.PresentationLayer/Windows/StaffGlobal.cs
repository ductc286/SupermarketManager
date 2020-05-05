using Supermarketmanagement.Core.ViewModels;
using SupermarketManagement.Core.Models;
using System;

namespace Supermarketmanagement.PresentationLayer.Windows
{
    public static class StaffGlobal
    {
        public static CurrentStaffViewModel CurrentStaff { get; set; } = new CurrentStaffViewModel() { Account = "Admin", StaffId = 1, StaffRole = 1 };
        public static string Account { 
            get 
            {
                var result = (CurrentStaff != null) ? CurrentStaff.Account : "";
                return result;
            } 
        }
        public static int StaffId
        {
            get
            {
                var result = (CurrentStaff != null) ? CurrentStaff.StaffId : 0;
                return result;
            }
        }
        public static string StaffRole
        {
            get
            {
                if (CurrentStaff == null)
                {
                    return "";
                }
                string result = Enum.GetName(typeof(StaffRole), CurrentStaff.StaffRole);
                return result;
            }
        }



    }
    // will remove this element
    //public  class Cc
    //{
    //    public StaffRole StaffRole1 = (StaffRole)1;
    //    public static void GetHi()
    //    {
    //        string m = Enum.GetName(typeof(StaffRole), 1);
    //        int d =(int) Enum.Parse(typeof(StaffRole), "SaleStaff");
    //        string bob = nameof(StaffRole.Administrator);
    //        var customerType = ((StaffRole)(1)).ToString();
    //        var e = Enum.Parse(typeof(StaffRole), "SaleStaff");
    //        string h = e.ToString();
    //        var f = 1;
    //    }
    //}
}
