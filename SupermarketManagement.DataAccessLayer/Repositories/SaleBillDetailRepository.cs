using SupermarketManagement.Core.Models;
using SupermarketManagement.DataAccessLayer.GenericRepository;
using SupermarketManagement.DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace SupermarketManagement.DataAccessLayer.Repositories
{
    public class SaleBillDetailRepository : GenericRepository<SaleBillDetail>, ISaleBillDetailRepository
    {
        public override bool Add(SaleBillDetail entity)
        {
            var isSuccess = base.Add(entity);
            if (isSuccess)
            {
                TriggerQuantityReduced(entity.Quantity, entity.ProductId);
                return true;
            }
            return false;
        }

        public override bool AddRange(IEnumerable<SaleBillDetail> entities)
        {
            foreach (var item in entities)
            {
                Add(item);
            }
            return true;
        }

        public override bool Update(SaleBillDetail entity)
        {
            var oldSaleBillDetail = MyDbSet.Find(entity.Id);
            var oldQuantity = oldSaleBillDetail.Quantity;
            var newQuantity = entity.Quantity;
            var changedQuantity = Math.Abs(newQuantity - oldQuantity);
            var isSuccess = base.Update(entity);
            if (isSuccess)
            {
                if (newQuantity < oldQuantity)
                {
                    TriggerQuantityIncrease(changedQuantity, entity.ProductId);
                }
                else if (newQuantity > oldQuantity)
                {
                    TriggerQuantityReduced(changedQuantity, entity.ProductId);
                }
                return true;
            }
            return false;
        }

        public override bool UpdateRange(IEnumerable<SaleBillDetail> entities)
        {
            foreach (var item in entities)
            {
                Update(item);
            }
            return true;
        }

        public override bool Delete(SaleBillDetail entity)
        {
            var isSuccess = base.Delete(entity);
            if (isSuccess)
            {
                TriggerQuantityIncrease(entity.Quantity, entity.ProductId);
                return true;
            }
            return false;
        }

        public override bool DeleteRange(IEnumerable<SaleBillDetail> entities)
        {
            foreach (var item in entities)
            {
                Delete(item);
            }
            return true;
        }

        #region trigger change quantity, update Inventory of product
        private void TriggerQuantityIncrease(int quantity, int productId)
        {
            var product = MyContext.Products.Find(productId);
            var newInventory = product.Inventory - quantity;
            product.Inventory = newInventory;
            MyContext.Products.AddOrUpdate(product);
            MyContext.SaveChanges();
        }

        private void TriggerQuantityReduced(int quantity, int productId)
        {
            var product = MyContext.Products.Find(productId);
            var newInventory = product.Inventory + quantity;
            product.Inventory = newInventory;
            MyContext.Products.AddOrUpdate(product);
            MyContext.SaveChanges();
        }
        #endregion
    }

}
