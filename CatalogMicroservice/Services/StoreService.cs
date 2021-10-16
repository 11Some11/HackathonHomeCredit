using CatalogMicroservice.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogMicroservice.Services
{
    public class StoreService : IStoreService
    {
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();
        public List<Store> GetAllStores()
        {
            return _dbContext.Stores.ToList();
        }

        public Store GetStoreById(Guid storeId)
        {
            foreach (var store in GetAllStores())
                if (store.Id.Equals(storeId))
                    return store;
            throw new Exception("No such store with id " + storeId);
        }

        public Store GetStoreByName(string name)
        {
            foreach (var store in GetAllStores())
                if (store.Name.Equals(name))
                    return store;
            throw new Exception("No such store with name " + name);
        }
    }
}
