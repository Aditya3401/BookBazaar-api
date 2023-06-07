using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.Book;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Vendor.Commands
{
    public class PublishBookCommand:IRequest<Books>
    {
        public Guid userId { get; set; }
        public BookDto bookDto { get; set; }
    }

}
