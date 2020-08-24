using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFoodApp.Web.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFoodApp.Web.WebMvc.ViewModels
{
    public class SearchIndexViewModel
    {
//public object SearchItems { get; internal set; }
        public IEnumerable<SearchItem> SearchItems { get; set; }
        public IEnumerable<SelectListItem> Restaurants { get; set; }
        public int? RestaurantFilterApplied { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
