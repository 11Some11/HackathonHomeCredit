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
    public class ItemController : ControllerBase
    {
        private IItemService _itemService = new ItemService();
        private IItemCategoryService _itemCategoryService = new ItemCategoryService();
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();

        [HttpGet("GetAllItems")]
        public IEnumerable<Item> GetAllItems()
        {
            return _itemService.GetAllItems();
        }

        [HttpGet("GetAllItemsOfCategory")]
        public IEnumerable<Item> GetAllItemsOfCategory(string categoryName)
        {
            return (IEnumerable<Item>)_itemService.GetAllItemsOfCategory(categoryName);
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<Item>> Post(Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            if (!item.CategoryName.Equals("")) {
                Guid itemCategoryId = _itemCategoryService.GetIdByName(item.CategoryName);
                item.Id = itemCategoryId;
            }
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("DeleteAll")]
        public async void DeleteAll()
        {
            _dbContext.Items.RemoveRange(_dbContext.Items.ToList());
            await _dbContext.SaveChangesAsync();
        }

    }
}
