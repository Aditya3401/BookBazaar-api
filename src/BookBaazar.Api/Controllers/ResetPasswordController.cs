using BookBaazar.Application.Endpoints.Password;
using BookBaazar.Application.Endpoints.Password.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBaazar.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ResetPasswordController(IMediator mediator)
        {
            _mediator = mediator;   
            
        }
        [HttpPost]
        [Route("ResetPassword/{useremail}")]
        public async Task<ActionResult> ResetPassword(string useremail, [FromBody] ResetPassword resetPassword)
        {
            bool isreset=await _mediator.Send(new PasswordResetCommand { useremail = useremail,resetpassword=resetPassword });
            if (isreset)
            {
                return Ok(new { message = "Password reset Successfully.Kindly Login Again." , isreset } );
            }
            return BadRequest();
        }
    }
}
