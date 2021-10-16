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
    public class StoreController : ControllerBase
    {
        private IStoreService _storeService = new StoreService();
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();

        [HttpGet("GetAll")]
        public IEnumerable<Store> GetAll()
        {
            return (IEnumerable<Store>)_storeService.GetAllStores();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Store>> Post(Store store)
        {
            if (store == null)
            {
                return BadRequest();
            }

            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync();
            return Ok(store);
        }

        [HttpDelete("DeleteByName")]
        public async void Delete(string storeName)
        {
            Store storeToDelete = _storeService.GetStoreByName(storeName);
            _dbContext.Stores.Remove(storeToDelete);
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete("Delete")]
        public async void Delete(Guid storeId)
        {
            Store storeToDelete = _storeService.GetStoreById(storeId);
            _dbContext.Stores.Remove(storeToDelete);
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete("deleteAll")]
        public async void DeleteAll()
        {
            _dbContext.Stores.RemoveRange(_dbContext.Stores.ToList());
            await _dbContext.SaveChangesAsync();
        }

    }
}
