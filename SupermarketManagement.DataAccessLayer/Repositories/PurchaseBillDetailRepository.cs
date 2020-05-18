﻿using SupermarketManagement.Core.Models;
using SupermarketManagement.DataAccessLayer.DatabaseContext;
using SupermarketManagement.DataAccessLayer.GenericRepository;
using SupermarketManagement.DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace SupermarketManagement.DataAccessLayer.Repositories
{
    public class PurchaseBillDetailRepository : GenericRepository<PurchaseBillDetail>, IPurchaseBillDetailRepository
    {
        public override bool Add(PurchaseBillDetail entity)
        {
            var isSuccess = base.Add(entity);
            if (isSuccess)
            {
                TriggerQuantityIncrease(entity.Quantity, entity.ProductId);
            }
            return false;
        }

        public override bool AddRange(IEnumerable<PurchaseBillDetail> entities)
        {
            foreach (var item in entities)
            {
                Add(item);
            }
            return true;
        }

        public override bool Delete(PurchaseBillDetail entity)
        {
            var isSuccess = base.Delete(entity);
            if (isSuccess)
            {
                TriggerQuantityReduced(entity.Quantity, entity.ProductId);
            }
            return false;
        }

        public override bool DeleteRange(IEnumerable<PurchaseBillDetail> entities)
        {
            foreach (var item in entities)
            {
                Delete(item);
            }
            return true;
        }

        public override bool Update(PurchaseBillDetail entity)
        {
            var oldPurchaseBillDetail = MyDbSet.Find(entity.Id);
            var oldQuantity = oldPurchaseBillDetail.Quantity;
            var newQuantity = entity.Quantity;
            var changedQuantity = Math.Abs(newQuantity - oldQuantity);
            var isSuccess = base.Update(entity);
            if (isSuccess)
            {
                if (newQuantity < oldQuantity)
                {
                    TriggerQuantityReduced(changedQuantity, entity.ProductId);
                }
                else if (newQuantity > oldQuantity)
                {
                    TriggerQuantityIncrease(changedQuantity, entity.ProductId);
                }
                
            }
            return false;
        }

        public override bool UpdateRange(IEnumerable<PurchaseBillDetail> entities)
        {
            foreach (var item in entities)
            {
                Update(item);
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
