using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFoodApp.Web.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFoodApp.Web.WebMvc.Services
{
   public  interface ISearchService
    {
        Task<Search> GetSearchItems(int page, int take, int? restuarant);
        Task<IEnumerable<SelectListItem>> GetRestaurant();
    }
}
