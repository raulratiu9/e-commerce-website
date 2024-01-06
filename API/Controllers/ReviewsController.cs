using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ReviewsController : BaseApiController
    {
        private readonly StoreContext _context;
        public ReviewsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetReviewsByProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return NotFound();

            return await _context.Reviews.Where(r => r.ProductId == productId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Review>> AddReviewToProduct(int productId, int stars, string message)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return NotFound();

            var review = new Review
            {
                ProductId = productId,
                Stars = stars,
                Message = message,
                Username = User.Identity.Name
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}