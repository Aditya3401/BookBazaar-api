using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Vendor.Queries
{
    public class GetVendor_Published_BooksQuery:IRequest<List<Books>>
    {
        public Guid userId { get; set; }  
    }
}
