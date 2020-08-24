using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderMyFood.Web.WebMvc.Models;
using OrderMyFood.Web.WebMvc.Models.ReviewModel;
using OrderMyFood.Web.WebMvc.Services;
using OrderMyFoodApp.Web.WebMvc.Models;
using OrderMyFoodApp.Web.WebMvc.Services;

namespace OrderMyFood.Web.WebMvc.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IIdentityService<ApplicationUser> _identityService;

        public ReviewController(IReviewService reviewService, IIdentityService<ApplicationUser> identityService)
        {
            _reviewService = reviewService;
            _identityService = identityService;
        }

        public async Task<ActionResult> Index(int id)
        {
            IEnumerable<Review> reviews = await _reviewService.GetReviews(id);
            return View(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            review.ReviewDate = DateTime.Now;
            var user = _identityService.Get(HttpContext.User);

            await _reviewService.CreateReview(user, review);

            return RedirectToAction("Index", "Review");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateReview(Review review)
        {
            var user = _identityService.Get(HttpContext.User);
            if (review.UserId == Int32.Parse(user.Id))
            {
                review.ReviewDate = DateTime.Now;
                await _reviewService.UpdateReview(review);
            }

            return RedirectToAction("Index", "Review");

        }


    }



}

