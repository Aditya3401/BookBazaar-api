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
    public class FilterBooksByCategoryQueryHandler : IRequestHandler<FilterBooksByCategoryQuery, List<Books>>
    {
        private readonly IBookService _bookService;
        public FilterBooksByCategoryQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<List<Books>> Handle(FilterBooksByCategoryQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookService.FilterBooksByCategory(request.categoryId);
            return books;
        }
    }
}
