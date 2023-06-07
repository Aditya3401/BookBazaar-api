using BookBaazar.Application.Endpoints.Book.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookBaazar.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var booksList = await _mediator.Send(new GetBooksQuery());
            return Ok(booksList);
        }

        [HttpGet]
        [Route("GetBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(Guid bookId)
        {
            var book = await _mediator.Send(new GetBookByIdQuery { bookId = bookId });
            return Ok(book);
        }

        [HttpGet]
        [Route("GetTrendingBooks")]
        public async Task<IActionResult> GetTrendingBooks()
        {
            var trendingBooks = await _mediator.Send(new GetTrendingBooksQuery());
            return Ok(trendingBooks);
        }

        [HttpGet]
        [Route("FilterBooksByCategory/{categoryId}")]
        public async Task<IActionResult> FilterBooksByCategory(Guid categoryId)
        {
            var Books = await _mediator.Send(new FilterBooksByCategoryQuery { categoryId = categoryId});
            return Ok(Books);
        }
    }
}
