using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OrderMyFood.Web.WebMvc.Models;
using OrderMyFood.Web.WebMvc.Models.ReviewModel;
using OrderMyFoodApp.Web.WebMvc.Infrastructure;
using OrderMyFoodApp.Web.WebMvc;
using OrderMyFoodApp.Web.WebMvc.Services;
using OrderMyFoodApp.Web.WebMvc.Models;

namespace OrderMyFood.Web.WebMvc.Services
{
    public class ReviewService : IReviewService
    {

        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<SearchService> _logger;

        private readonly string _remoteServiceBaseUrl;
        public ReviewService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<SearchService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.SearchUrl}/api/Review/";
        }
        public async Task<Review> CreateReview(ApplicationUser user, Review review)
        {
            review.UserId = Int32.Parse(user.Id);

            var ReviewsUri = ApiPaths.Review.UpdateReview(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(ReviewsUri);

            var response = JsonConvert.DeserializeObject<Review>(dataString);

            return response;
        }

        public async Task<IEnumerable<Review>> GetReviews(int RestaurantId)
        {
            var ReviewsUri = ApiPaths.Review.GetReviews(_remoteServiceBaseUrl, RestaurantId);

            var dataString = await _apiClient.GetStringAsync(ReviewsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Review>>(dataString);

            return response;
        }

        public async Task<Review> UpdateReview(Review review)
        {


            var ReviewsUri = ApiPaths.Review.UpdateReview(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(ReviewsUri);

            var response = JsonConvert.DeserializeObject<Review>(dataString);

            return response;
        }
    }
}
