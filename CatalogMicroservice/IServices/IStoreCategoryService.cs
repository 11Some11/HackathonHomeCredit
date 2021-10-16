using System;
using System.Collections.Generic;

namespace CatalogMicroservice.IServices
{
    interface IStoreCategoryService
    {
        public StoreCategory GetStoreCategoryByName(string storeName);
        public StoreCategory GetStoreCategoryById(Guid storeId);
        public List<StoreCategory> GetAllStoreCategories();
    }
}
