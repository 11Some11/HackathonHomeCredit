using System;
using System.Collections.Generic;

namespace CatalogMicroservice.IServices
{
    interface IProducerService
    {
        public List<Producer> GetAllProducers();
        public Producer GetProducerByName(string name);
        public Producer GetProducerById(Guid id);
    }
}
