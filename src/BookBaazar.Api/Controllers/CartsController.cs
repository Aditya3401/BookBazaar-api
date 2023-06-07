using BookBaazar.Application.Endpoints.Cart;
using BookBaazar.Application.Endpoints.Cart.Commands;
using BookBaazar.Application.Endpoints.Cart.Queries;
using BookBaazar.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBaazar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult>AddToCart([FromBody] CartsDto carts)
        {
            var item=await _mediator.Send(new AddToCartCommand { item = carts });
            return Ok(item);
        }
        [HttpPost]
        [Route("DecreaseFromCart")]
        public async Task<ActionResult> DecreaseFromCart([FromBody] CartsDto carts)
        {
            var item=await _mediator.Send(new DecreaseFromCartCommand { item = carts });
            return Ok(item);
        }
        [HttpPost]
        [Route("RemoveFromCart")]
        public async Task<ActionResult> RemovedFromCart([FromBody] CartsDto carts)
        {
            bool isRemoved= await _mediator.Send(new RemoveFromCartCommand { item = carts });
           
                return Ok(new
                {
                    message = "Item Removed From Cart Successfully",
                    isRemoved
                });
            
        }
        [HttpGet]
        [Route("GetCart")]
        public async Task<ActionResult> GetCart(Guid userId)
        {
            var cart= await _mediator.Send(new GetCartQuery { userId = userId });
            return Ok(cart);
        }
    }
}
