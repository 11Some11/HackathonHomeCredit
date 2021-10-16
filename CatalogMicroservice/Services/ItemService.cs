using CatalogMicroservice.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogMicroservice.Services
{
    public class ItemService : IItemService
    {
        private CatalogMicroservicesContext dbContext = new CatalogMicroservicesContext();
        private IItemCategoryService _itemCategoryService = new ItemCategoryService();

        public List<Item> GetAllItems()
        {
            return dbContext.Items.ToList();
        }

        public List<Item> GetAllItemsOfCategory(string categoryName)
        {
            Guid categoryId = _itemCategoryService.GetIdByName(categoryName);
            List<Item> allItems = dbContext.Items.ToList();
            List<Item> itemsOfCategory = new List<Item>();
            foreach (var item in allItems)
            {
                if (item.CategoryId == categoryId)
                {
                    itemsOfCategory.Add(item);
                }
            }
            return itemsOfCategory;
        }
    }
}
