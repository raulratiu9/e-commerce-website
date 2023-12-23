using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly StoreContext _context;

        public BasketController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket()
        {
            var basket = await _context
                .Baskets
                .Include(i => i.Items)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(x => x.BuyerId == RequestCookiesFeature["buyerId"]);

            if (basket == null)
                return NotFound();

            return basket;
        }

        // [HttpPost]
        // public async Task<ActionResult> AddItemToBasket(int productId, int quantity)
        // {
        //     return StatusCodeHttpResult(201);
        // }

        // [HttpDelete]
        // public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
        // {
        //     return StatusCodeHttpResult(201);
        // }
    }

    public class BaseApiController { }
}
