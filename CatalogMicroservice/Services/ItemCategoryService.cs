using CatalogMicroservice.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogMicroservice.Services
{
    public class ItemCategoryService : IItemCategoryService
    {
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();
        public List<ItemCategory> GetAllItemCategories()
        {
            return _dbContext.ItemCategories.ToList();
        }

        public ItemCategory GetItemCategoryByName(String name)
        {
            foreach (var category in GetAllItemCategories())
            {
                if (category.Name.Equals(name))
                    return category;
            }
            throw new Exception("no such category exists with name " + name);
        }
        public Guid GetIdByName(string name)
        {
            foreach (var category in GetAllItemCategories())
            {
                if (category.Name.Equals(name))
                    return category.Id;
            }
            throw new Exception("no such category exists with name " + name);
        }
    }
}
