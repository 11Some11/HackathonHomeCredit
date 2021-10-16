using CatalogMicroservice.IServices;
using CatalogMicroservice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreCategoryController : ControllerBase
    {
        private IStoreCategoryService _storeCategoryService = new StoreCategoryService();
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();

        [HttpGet("GetAll")]
        public IEnumerable<StoreCategory> GetAll()
        {
            return (IEnumerable<StoreCategory>)_storeCategoryService.GetAllStoreCategories();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<StoreCategory>> Post(StoreCategory store)
        {
            if (store == null)
            {
                return BadRequest();
            }

            _dbContext.StoreCategories.Add(store);
            await _dbContext.SaveChangesAsync();
            return Ok(store);
        }

        [HttpDelete("DeleteByName")]
        public async void Delete(string storeName)
        {
            StoreCategory storeCategoryToDelete = _storeCategoryService.GetStoreCategoryByName(storeName);
            _dbContext.StoreCategories.Remove(storeCategoryToDelete);
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete("DeleteById")]
        public async void Delete(Guid storeId)
        {
            StoreCategory storeCategoryToDelete = _storeCategoryService.GetStoreCategoryById(storeId);
            _dbContext.StoreCategories.Remove(storeCategoryToDelete);
            await _dbContext.SaveChangesAsync();
        }
        [HttpDelete("deleteAll")]
        public async void DeleteAll()
        {
            _dbContext.StoreCategories.RemoveRange(_dbContext.StoreCategories.ToList());
            await _dbContext.SaveChangesAsync();
        }

    }
}
