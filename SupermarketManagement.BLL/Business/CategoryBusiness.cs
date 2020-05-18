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
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusiness()
        {
            _categoryRepository = new CategoryRepository();
        }

        public bool Add(CategoryViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var category = new Category()
            {
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
            return _categoryRepository.Add(category);
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public Category GetById(object id)
        {
            return _categoryRepository.GetById(id);
        }

        public bool Update(CategoryViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var findCategory = _categoryRepository.GetById(entity.CategoryId);
            if (findCategory == null)
            {
                return false;
            }
            findCategory.CategoryName = entity.CategoryName;
            findCategory.Description = entity.Description;
            return _categoryRepository.Update(findCategory);
        }
    }
}
