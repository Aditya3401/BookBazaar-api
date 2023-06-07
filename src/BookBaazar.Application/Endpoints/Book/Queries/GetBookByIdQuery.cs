using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Book.Queries
{
    public class GetBookByIdQuery : IRequest<Books>
    {
        public Guid bookId { get; set; }
    }
}
