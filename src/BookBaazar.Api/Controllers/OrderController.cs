using System.CodeDom.Compiler;
using BookBaazar.Application.Endpoints.Order;
using BookBaazar.Application.Endpoints.Order.Commands;
using BookBaazar.Application.Endpoints.Order.Queries;
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
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("GenerateOrder/{userId}")]
        public async Task<ActionResult> GenerateOrder(Guid userId, [FromBody] OrderDto orderDto)
        {
            var item= await _mediator.Send(new GenerateOrderCommand { userId=userId,order=orderDto});
            if (item!=null)
            {
                return Ok(new {message="Order Placed Successfully",item});
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CompleteOrderProcess")]
        public async Task<ActionResult> CompleteOrderProcess([FromServices] IHttpContextAccessor httpContextAccessor)
        {
            var response = await _mediator.Send(new CompleteOrderProcessCommand { httpContextAccessor = httpContextAccessor });
            if (response!=null)
            {
                return Redirect($"http://localhost:3000/paymentsuccess/{response}");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("CancelOrder")]
        public async Task<ActionResult> CancelOrder(string orderId)
        {
            bool iscancelled= await _mediator.Send(new CancelOrderCommand { orderId=orderId});
            if (iscancelled)
            {
                return Ok(new { message = "Order Cancelled Succesfully", iscancelled });
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetOrder/{orderId}")]
        public async Task<List<OrderBooksRead>> GetOrder(string orderId)
        {
            var result= await _mediator.Send(new GetOrderCommand { orderId=orderId});
            return result;
        }

        [HttpGet]
        [Route("GetOrdersOfUser/{userId}")]
        public async Task<List<Orders>> GetOrdersOfUser(Guid userId)
        {
            var orders = await _mediator.Send(new GetOrdersOfUserQuery { userId=userId });
            return orders;
        }

        [HttpGet]
        [Route("GetParticularOrder/{orderId}")]
        public async Task<Orders> GetParticularOrder(string orderId)
        {
            var order = await _mediator.Send(new GetParticularOrderQuery { orderId = orderId});
            return order;
        }
    }
}
