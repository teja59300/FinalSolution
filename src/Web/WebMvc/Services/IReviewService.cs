 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderMyFood.Web.WebMvc.Models;
using OrderMyFood.Web.WebMvc.Models.ReviewModel;
using OrderMyFoodApp.Web.WebMvc.Models;

namespace OrderMyFood.Web.WebMvc.Services
    {
        public interface IReviewService
        {
            Task<IEnumerable<Review>> GetReviews(int RestaurantId);
            Task<Review> UpdateReview(Review review);
            Task<Review> CreateReview(ApplicationUser user, Review review);
        }
    }


