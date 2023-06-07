using BookBaazar.Application.Endpoints.Admin.Commands;
using BookBaazar.Application.Endpoints.Book;
using BookBaazar.Application.Endpoints.Book.Queries;
using BookBaazar.Application.Endpoints.Vendor.Commands;
using BookBaazar.Application.Endpoints.Vendor.Queries;
using BookBaazar.Domain.Entities;
using BookBaazar.Application.AWS;
using BookBaazar.Application.Endpoints.AWS.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookBaazar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public VendorController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPut]
        [Route("ConvertToVendor/{userId}")]
        public async Task<ActionResult> ConvertToVendor(Guid userId)    
        {
            var isConverted = await _mediator.Send(new ConvertToVendorCommand { userId = userId });
            return Ok(new
            {
                message = "User is now a Vendor",
                isConverted
            });
        }

        [HttpGet]
        [Route("GetVendor_Published_Books/{userId}")]
        public async Task<ActionResult> GetVendor_Published_Books(Guid userId)
        {
            var Books = await _mediator.Send(new GetVendor_Published_BooksQuery { userId=userId });
            return Ok(Books);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file, Guid userId)
        {
            bool isuploaded = await _mediator.Send(new UploadFileCommand { file = file, userId = userId });
            if (isuploaded)
            {
                return Ok(new { message = "File Uploaded succesfully", isuploaded });

            }
            return BadRequest();

        }

        [HttpPut]
        [Route("StatusBook/{bookId}")]
        public async Task<ActionResult> StatusBook(Guid bookId)
        {
            var isStatus = await _mediator.Send(new StatusBookCommand { bookId = bookId });
            if (isStatus)
            {
                return Ok(new
                {
                    message = $"Book Status Changed To Active Successfully",
                    isStatus
                });
            }
            return Ok(new { message = "Book Status Changed To INActive Successfully.", isStatus });
        }

        [HttpPost]
        [Route("PublishBook/{userId}")]
        public async Task<ActionResult> PublishBook(Guid userId, BookDto bookDto)
        {
            var book = await _mediator.Send(new PublishBookCommand { userId = userId,bookDto=bookDto });
            if(book == null)
            {
                return BadRequest(new { message = "Book Publish Unsuccessfull" });
            }
            return Ok( new { message = "Book Published Successfully", book });
        }
    }
}
