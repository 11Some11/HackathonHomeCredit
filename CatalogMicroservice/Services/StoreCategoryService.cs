using CatalogMicroservice.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogMicroservice.Services
{
    public class StoreCategoryService : IStoreCategoryService
    {
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();
        public List<StoreCategory> GetAllStoreCategories()
        {
            return _dbContext.StoreCategories.ToList();
        }

        public StoreCategory GetStoreCategoryById(Guid storeId)
        {
            foreach (var storeCategory in GetAllStoreCategories())
                if (storeCategory.Id.Equals(storeId))
                    return storeCategory;
            throw new Exception("No such storeCategory with id " + storeId);
        }

        public StoreCategory GetStoreCategoryByName(string name)
        {
            foreach (var storeCategory in GetAllStoreCategories())
                if (storeCategory.Name.Equals(name))
                    return storeCategory;
            throw new Exception("No such storeCategory with name " + name);
        }

    }
}
