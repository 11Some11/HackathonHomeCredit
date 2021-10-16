using System;
using System.Collections.Generic;

namespace CatalogMicroservice.IServices
{
    interface IItemCategoryService
    {
        public List<ItemCategory> GetAllItemCategories();
        public ItemCategory GetItemCategoryByName(string name);
        public Guid GetIdByName(string name);
    }
}
