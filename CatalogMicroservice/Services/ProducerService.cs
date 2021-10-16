
using CatalogMicroservice.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogMicroservice.Services
{
    public class ProducerService : IProducerService
    {
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();
        public List<Producer> GetAllProducers()
        {
            return _dbContext.Producers.ToList();
        }

        public Producer GetProducerById(Guid id)
        {
            foreach (var store in GetAllProducers())
                if (store.Id.Equals(id))
                    return store;
            throw new Exception("No such producer with id " + id);
        }
        public Producer GetProducerByName(string name)
        {
            foreach (var producer in GetAllProducers())
                if (producer.Name.Equals(name))
                    return producer;
            throw new Exception("No such producer with name " + name);
        }
    }
}
