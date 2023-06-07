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
    public class GetTrendingBooksQueryHandler : IRequestHandler<GetTrendingBooksQuery, List<Books>>
    {
        private readonly IBookService _bookService;
        public GetTrendingBooksQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public Task<List<Books>> Handle(GetTrendingBooksQuery request, CancellationToken cancellationToken)
        {
            var trendingBooks = _bookService.GetTrendingBooks();
            return trendingBooks;
        }
    }
}
