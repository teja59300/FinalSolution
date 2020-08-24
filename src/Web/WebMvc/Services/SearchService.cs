using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderMyFoodApp.Web.WebMvc.Infrastructure;
using OrderMyFoodApp.Web.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFoodApp.Web.WebMvc.Services
{
    public class SearchService:ISearchService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<SearchService> _logger;

        private readonly string _remoteServiceBaseUrl;
        public SearchService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<SearchService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.SearchUrl}/api/search/";
        }

        public async Task<Search> GetSearchItems(int page, int take, int? restaurant)
        {
            var allsearchItemsUri = ApiPaths.Search.GetAllSearchItems(_remoteServiceBaseUrl, page, take, restaurant);

            var dataString = await _apiClient.GetStringAsync(allsearchItemsUri);

            var response = JsonConvert.DeserializeObject<Search>(dataString);

            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetRestaurant()
        {
            var getRestaurantsUri = ApiPaths.Search.GetAllRestaurant(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getRestaurantsUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var restuarants = JArray.Parse(dataString);

            foreach (var restuarant in restuarants.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = restuarant.Value<string>("id"),
                    Text = restuarant.Value<string>("restuarant")
                });
            }

            return items;
        }

    }
}
