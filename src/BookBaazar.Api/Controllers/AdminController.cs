using BookBaazar.Application.Endpoints.User.Queries;
using BookBaazar.Application.Endpoints.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BookBaazar.Application.Endpoints.Admin.Queries;
using BookBaazar.Application.Endpoints.Admin.Commands;
using BookBaazar.Application.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookBaazar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var usersList = await _mediator.Send(new GetUsersQuery());
            return Ok(usersList);
        }

        [HttpGet]
        [Route("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery{ userId = userId});
            return Ok(user);
        }

        [HttpPut]
        [Route("UpdateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId)
        {
            var isUpdated = await _mediator.Send(new UpdateUserCommand { userId = userId });
            if(isUpdated)
            {
                return Ok(new
                {
                    message = "User Updated to active Successfully",
                    isUpdated
                });
            }
            return Ok(new
            {
                message = "User Updated to inactive Successfully",
                isUpdated
            });
        }
    }
}
