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
    public class ItemAtStoresController : ControllerBase
    {
        private CatalogMicroservicesContext _dbContext = new CatalogMicroservicesContext();
        [HttpPost("AddItemFromStore")]
        public async Task<ActionResult<Producer>> Post(ItemStores itemStores)
        {
            if (itemStores == null)
            {
                return BadRequest();
            }

            _dbContext.ItemStores.Add(itemStores);
            await _dbContext.SaveChangesAsync();
            return Ok(itemStores);
        }

    }
}
