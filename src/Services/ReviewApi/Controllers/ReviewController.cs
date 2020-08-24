using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantApi.DataAccess;
using RestaurantApi.Domain.Model;

namespace ReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReviewController : ControllerBase
    {

        private readonly ReviewDbContext _ReviewContext;
        private ILogger _logger;

        public ReviewController(ReviewDbContext context, ILoggerFactory factory)
        {
            _ReviewContext = context;
            _logger = factory.CreateLogger<ReviewController>();
        }



        [HttpGet]
        [Route("[action]{Restaurantid}")]
        public async Task<IActionResult> Items(int RestaurantId)
        {
            var items = await _ReviewContext.Reviews.Where(x => x.RestaurantId == RestaurantId)
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet]
        [Route("[action]{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var items = await _ReviewContext.Reviews.Where(x => x.ReviewId == id)
                .ToListAsync();

            return Ok(items);
        }

        [Route("items")]
        [HttpPut]
        public async Task<IActionResult> Item([FromBody]Review reviewToUpdate)
        {
            var review = await _ReviewContext.Reviews
                .SingleOrDefaultAsync(i => i.ReviewId == reviewToUpdate.ReviewId);

            if (review == null)
            {
                return NotFound(new { Message = $"Item with id {reviewToUpdate.ReviewId} not found." });
            }


            review.ReviewId = reviewToUpdate.ReviewId;
            review.Rating = reviewToUpdate.Rating;
            review.ReviewDate = reviewToUpdate.ReviewDate;
            review.RestaurantId = reviewToUpdate.RestaurantId;
            review.UserId = reviewToUpdate.UserId;
            review.Comment = reviewToUpdate.Comment;

            // _ReviewContext.Reviews.Update(review);

            await _ReviewContext.SaveChangesAsync();
            // return Created("",review);

            return CreatedAtAction(nameof(GetItemById), new { id = reviewToUpdate.ReviewId }, null);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Items([FromBody]Review Review)
        {

            await _ReviewContext.Reviews.AddAsync(Review);

            int x = _ReviewContext.SaveChanges();
            // return Created("",review);
            return CreatedAtAction(nameof(GetItemById), new { id = Review.ReviewId }, null);
        }
    }
}

