using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestuarantSearchApi.Data;
using RestuarantSearchApi.Domain;
using RestuarantSearchApi.ViewModels;

namespace RestuarantSearchApi.Controllers
{
    [Route("api/Search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchItemContext _searchItemContext;
        private readonly IOptionsSnapshot<SearchSettings> _settings;
        public SearchController(SearchItemContext searchItemContext, IOptionsSnapshot<SearchSettings> settings)
        {
            _searchItemContext = searchItemContext;
            _settings = settings;
            ((DbContext)searchItemContext).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet]
        [Route("[action")]
        public async Task<IActionResult> RestaurantDetails()
        {
            var items = await _searchItemContext.RestaurantDetails.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var item = await _searchItemContext.SearchItems.SingleOrDefaultAsync(s => s.ItemId == id);
            if (item != null)
            {
                item.ItemPictureUrl = item.ItemPictureUrl.Replace("http://externalsearchbaseurltobereplaced", _settings.Value.ExternalSearchItemBaseUrl);
                return Ok(item);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery] int pageSize=6,[FromQuery] int pageIndex = 0)
        {
            var totalItems = await _searchItemContext.SearchItems
                .LongCountAsync();
            var itemsOnPage = await _searchItemContext.SearchItems
                .OrderBy(s => s.ItemName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
            itemsOnPage = ChangeUrlPlaceHolder(itemsOnPage);
            var model = new PaginatedItemViewModel<SearchItem>(pageIndex, pageSize, totalItems, itemsOnPage);
            return Ok(model);
        }


        //GET api/Catalog/items/withname/Wonder?pageSize=2&pageIndex=0
        [HttpGet]
        [Route("[action]/withname/{name:minlength(1)}")]
        public async Task<IActionResult> Items(string name,[FromQuery] int pageSize = 6, [FromQuery] int pageIndex = 0)
        {
            var totalItems = await _searchItemContext.SearchItems
                .Where(s=>s.ItemName.StartsWith(name))
                .LongCountAsync();
            var itemsOnPage = await _searchItemContext.SearchItems
               .Where(s => s.ItemName.StartsWith(name))
                .OrderBy(s => s.ItemName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
            itemsOnPage = ChangeUrlPlaceHolder(itemsOnPage);
            var model = new PaginatedItemViewModel<SearchItem>(pageIndex, pageSize, totalItems, itemsOnPage);
            return Ok(model);
        }


        //GET api/Catalog/items/type/1/null[?pageSize==4&pageIndex=0]
        [HttpGet]
        [Route("[action]/restaurant/{restaurantId}")]
        public async Task<IActionResult> Items(int ?  restaurantId, [FromQuery] int pageSize = 6, [FromQuery] int pageIndex = 0)
        {
            var root = (IQueryable<SearchItem>)_searchItemContext.SearchItems;

           if (restaurantId.HasValue)
            {
                root = root.Where(s => s.RestaurantId == restaurantId);
            }
            var totalItems = await root
                .LongCountAsync();
            var itemsOnPage = await _searchItemContext.SearchItems
                .OrderBy(s => s.ItemName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
            itemsOnPage = ChangeUrlPlaceHolder(itemsOnPage);
            var model = new PaginatedItemViewModel<SearchItem>(pageIndex, pageSize, totalItems, itemsOnPage);
            return Ok(model);
        }

        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> Create([FromBody] SearchItem search)
        {
            var item = new SearchItem
            {
                RestaurantId = search.RestaurantId,
                ItemName = search.ItemName,
                ItemPrice = search.ItemPrice,
                Quantity = search.Quantity,


            };
            _searchItemContext.SearchItems.Add(item);
            await _searchItemContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItemById), new { id = item.ItemId });
        }

        [HttpPut]
        [Route("items")]
        public async Task<IActionResult> Update([FromBody] SearchItem productToUpdate)
        {
            var searchItem = await _searchItemContext.SearchItems
                .SingleOrDefaultAsync(i => i.ItemId == productToUpdate.ItemId);
            if(searchItem==null)
            {
                return NotFound(new { Message = $"item with id{productToUpdate.ItemId} not found" });
            }
            searchItem = productToUpdate;
            _searchItemContext.SearchItems.Update(searchItem);
            await _searchItemContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItemById), new { id = productToUpdate.ItemId });
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            var product = await _searchItemContext.SearchItems.SingleOrDefaultAsync(p => p.ItemId == id);
            if (product == null)
            {
                return NotFound();
            }
            _searchItemContext.SearchItems.Remove(product);
            await _searchItemContext.SaveChangesAsync();
            return NoContent();
        }
       

        private List<SearchItem> ChangeUrlPlaceHolder(List<SearchItem> items)
        {
            items.ForEach(
                x => x.ItemPictureUrl = x.ItemPictureUrl.Replace("http://externalsearchbaseurltobereplaced",
                _settings.Value.ExternalSearchItemBaseUrl));
            return items;
        }
    }
}