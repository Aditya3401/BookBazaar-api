using BookBaazar.Application.Endpoints.User.Commands;
using BookBaazar.Application.Endpoints.User;
using BookBaazar.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BookBaazar.Application.Interfaces.Persistence.DataServices.User;
using BookBaazar.Application.Endpoints.User.Queries;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookBaazar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto userDTO)
        {
            bool emailExists = await _mediator.Send(new CheckEmailExistsQuery { Email = userDTO.Email });
            if (emailExists)
            {
                return BadRequest("User with the specified email already exists.");
            }
            Users newUser = await _mediator.Send(new UserRegistrationCommand { UserDTO = userDTO });
            return Ok(new
            {
                message = "User Registered Successfully"
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto loginDTO)
        {
            var query = new ReadUserQuery { loginUser = loginDTO };
            var userDTO = await _mediator.Send(query);

            if (userDTO != null)
            {
                return Ok(userDTO);
            }
            else
            {
                return BadRequest("invalid email or password");
            }
        }
    }
}
