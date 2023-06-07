using BookBaazar.Application.Endpoints.ForgotPassword;
using BookBaazar.Application.Endpoints.Mail.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBaazar.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MailController(IMediator mediator)
        {
            _mediator = mediator;   
            
        }
        [HttpPost]
        [Route("SendMail")]
        public async Task<ActionResult> SendMailAsync([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            bool isresult=await _mediator.Send(new SendMailAsyncCommand { forgotPasswordDto= forgotPasswordDto });
            if (!isresult)
            {
                return BadRequest();
            }
            return Ok(new { message = "Email Sent successfully", isresult });
        }
    }
}
