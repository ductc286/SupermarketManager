using SupermarketManagement.Core.Models;
using System;
using System.Data.Entity;

namespace SupermarketManagement.DataAccessLayer.DatabaseContext
{
    public class MyInitializer : CreateDatabaseIfNotExists<MyDBContext>
    {
        protected override void Seed(MyDBContext context)
        {
            //// Seed data in here
            #region Component which sure is need for this system
            var staff = new Staff() {
                Account = "Admin",
                FullName = "Administrator",
                StaffRole = (int)StaffRole.Administrator,
                CreatedDate = DateTime.Now,
                PasswordHash = "234ksf"
            };
            context.Staffs.Add(staff);
            context.SaveChanges();
            #endregion
            base.Seed(context);
        }
    }
}