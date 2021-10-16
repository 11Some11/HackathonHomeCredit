using System.Collections.Generic;

namespace CatalogMicroservice.IServices
{
    public interface IItemService
    {
        public List<Item> GetAllItemsOfCategory(string categoryName);
        public List<Item> GetAllItems();
    }
}
