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
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Books>
    {
        private readonly IBookService _bookService;
        public GetBookByIdQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Books> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookById(request.bookId);
            return book;
        }
    }
}
