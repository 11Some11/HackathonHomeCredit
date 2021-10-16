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
    public class ItemCategoryController : ControllerBase
    {
        private IItemCategoryService _itemCategoryService = new ItemCategoryService();
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();
        
        [HttpGet("GetAll")]
        public IEnumerable<ItemCategory> GetAll()
        {
            return _itemCategoryService.GetAllItemCategories();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ItemCategory>> Post(ItemCategory itemCategory)
        {
            if (itemCategory == null)
            {
                return BadRequest();
            }

            _dbContext.ItemCategories.Add(itemCategory);
            await _dbContext.SaveChangesAsync();
            return Ok(itemCategory);
        }

        [HttpDelete("Delete")]
        public async void Delete(string itemCategoryName)
        {
            ItemCategory itemToDelete = _itemCategoryService.GetItemCategoryByName(itemCategoryName);
            _dbContext.ItemCategories.Remove(itemToDelete);
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete("deleteAll")]
        public async void DeleteAll()
        {
            _dbContext.ItemCategories.RemoveRange(_dbContext.ItemCategories.ToList());
            await _dbContext.SaveChangesAsync();
        }
    }
}
