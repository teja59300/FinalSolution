using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMyFoodApp.Web.WebMvc.Services;
using OrderMyFoodApp.Web.WebMvc.ViewModels;
using WebMvc.Models;

namespace WebMvc.Controllers
{
   
    public class SearchController : Controller
    {
        private ISearchService _searchSvc;

        public SearchController(ISearchService searchSvc) =>
            _searchSvc = searchSvc;

        public async Task<IActionResult> Index(int? RestaurantsFilterApplied, int? page)
        {

            int itemsPage = 10;
            var search = await _searchSvc.GetSearchItems(page ?? 0, itemsPage, RestaurantsFilterApplied);
            var vm = new SearchIndexViewModel()
            {
                  
                SearchItems = search.Data,
                Restaurants = await _searchSvc.GetRestaurant(), 
                RestaurantFilterApplied = RestaurantsFilterApplied ?? 0,

                PaginationInfo = new PaginationInfo()
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsPage, //search.Data.Count,
                    TotalItems =  search.Count,
                    TotalPages = (int)Math.Ceiling(((decimal)search.Count / itemsPage))
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return View(vm);
        }
        //[Authorize]
        //public async Task<IActionResult> About()
        //{
        //    ViewData["Message"] = "Your application description page.";
        //    var user = User as ClaimsPrincipal;

        //    var token = await HttpContext.GetTokenAsync("access_token");
        //    var idToken = await HttpContext.GetTokenAsync("id_token");
        //    foreach (var claim in user.Claims)
        //    {
        //        Debug.WriteLine($"Claim Type: {claim.Type} - Claim Value : {claim.Value}");
        //    }

        //    if (token != null)
        //    {
        //        ViewData["access_token"] = token;

        //    }
        //    if (idToken != null)
        //    {

        //        ViewData["id_token"] = idToken;
        //    }

        //    return View();
        //}

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }




        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
