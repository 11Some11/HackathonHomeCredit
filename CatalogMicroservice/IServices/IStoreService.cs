using System;
using System.Collections.Generic;

namespace CatalogMicroservice.IServices
{
    interface IStoreService
    {
        public Store GetStoreByName(string name);
        public List<Store> GetAllStores();
        public Store GetStoreById(Guid storeId);
    }
}
