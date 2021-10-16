using CatalogMicroservice.IServices;
using CatalogMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private IProducerService _producerService = new ProducerService();
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();

        [HttpGet("GetAll")]
        public IEnumerable<Producer> GetAll()
        {
            return (IEnumerable<Producer>)_producerService.GetAllProducers();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Producer>> Post(Producer producer)
        {
            if (producer == null)
            {
                return BadRequest();
            }

            _dbContext.Producers.Add(producer);
            await _dbContext.SaveChangesAsync();
            return Ok(producer);
        }

        [HttpDelete("DeleteByName")]
        public async void Delete(string storeName)
        {
            Producer storeToDelete = _producerService.GetProducerByName(storeName);
            _dbContext.Producers.Remove(storeToDelete);
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete("DeleteById")]
        public async void Delete(Guid storeId)
        {
            Producer producerToDelete = _producerService.GetProducerById(storeId);
            _dbContext.Producers.Remove(producerToDelete);
            await _dbContext.SaveChangesAsync();
        }
        [HttpDelete("deleteAll")]
        public async void DeleteAll()
        {
            _dbContext.Producers.RemoveRange(_dbContext.Producers.ToList());
            await _dbContext.SaveChangesAsync();
        }
    }
}
