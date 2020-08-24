﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMyFoodApp.Web.WebMvc.Models;
using OrderMyFoodApp.Web.WebMvc.Models.CartModels;
using OrderMyFoodApp.Web.WebMvc.Services;
using Polly.CircuitBreaker;

namespace WebMvc.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private readonly ICartService _cartService;
        private readonly ISearchService _searchService;
        private readonly IIdentityService<ApplicationUser> _identityService;

        public CartController(IIdentityService<ApplicationUser> identityService, ICartService cartService, ISearchService searchService)
        {
            _identityService = identityService;
            _cartService = cartService;
            _searchService = searchService;



        }
        public IActionResult Index()
        {
            //try
            //{

            //    var user = _identityService.Get(HttpContext.User);
            //    var cart = await _cartService.GetCart(user);


            //    return View();
            //}
            //catch (BrokenCircuitException)
            //{
            //    // Catch error when CartApi is in circuit-opened mode                 
            //    HandleBrokenCircuitException();
            //}

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities, string action)
        {
            if (action == "[ Checkout ]")
            {
                // var order = _cartService.MapCartToOrder(cart);
                return RedirectToAction("Create", "Order");
                // return Redirect(Url.Action("Create", "Order", order));
            }

            try
            {
                var user = _identityService.Get(HttpContext.User);
                var cart = await _cartService.SetQuantities(user, quantities);
                var vm = await _cartService.UpdateCart(cart);


            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit  mode                 
                HandleBrokenCircuitException();
            }

            return View();

        }

        public async Task<IActionResult> AddToCart(SearchItem productDetails)
        {
            try
            {
                if (productDetails.ItemId != null)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var product = new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Quantity = 1,
                        ProductName = productDetails.Name,
                        PictureUrl = productDetails.ItemPictureUrl,
                        UnitPrice = productDetails.ItemPrice,
                        ProductId = productDetails.ItemId
                    };
                    await _cartService.AddItemToCart(user, product);
                }
                return RedirectToAction("Index", "Search");
            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in circuit-opened mode                 
                HandleBrokenCircuitException();
            }

            return RedirectToAction("Index", "Search");

        }
        //public async Task WriteOutIdentityInfo()
        //{
        //    var identityToken =
        //        await HttpContext.Authentication.
        //         GetAuthenticateInfoAsync(OpenIdConnectParameterNames.IdToken);
        //    Debug.WriteLine($"Identity Token: {identityToken}");
        //    foreach (var claim in User.Claims)
        //    {
        //        Debug.WriteLine($"Claim Type: {claim.Type} - Claim Value : {claim.Value}");
        //    }

        //}

        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }

    }
}