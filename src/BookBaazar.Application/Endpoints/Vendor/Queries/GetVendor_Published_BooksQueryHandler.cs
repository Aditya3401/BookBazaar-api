using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Vendor;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Vendor.Queries
{
    public class GetVendor_Published_BooksQueryHandler : IRequestHandler<GetVendor_Published_BooksQuery, List<Books>>
    {
        private readonly IVendorService _vendorService;
        public GetVendor_Published_BooksQueryHandler(IVendorService vendorService)
        {
            _vendorService = vendorService;
            
        }
        public async Task<List<Books>> Handle(GetVendor_Published_BooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _vendorService.GetVendor_Published_Books(request.userId);
            return books;
        }
    }
}
