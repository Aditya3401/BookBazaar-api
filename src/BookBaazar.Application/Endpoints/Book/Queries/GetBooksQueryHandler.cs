using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Book;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Book.Queries
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<Books>>
    {
        private readonly IBookService _bookService;
        public GetBooksQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<List<Books>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookService.GetBooks();
            return books;
        }
    }
}
