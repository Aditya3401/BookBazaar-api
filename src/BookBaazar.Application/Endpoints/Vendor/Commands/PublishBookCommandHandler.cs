using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Vendor;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Vendor.Commands
{
    public class PublishBookCommandHandler : IRequestHandler<PublishBookCommand, Books>
    {
        
        private readonly IVendorService _vendorService;
        public PublishBookCommandHandler(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }
        public async Task<Books> Handle(PublishBookCommand request, CancellationToken cancellationToken)
        {
            Books books = await _vendorService.PublishBook(request.userId, request.bookDto);
            return books;
            
        }
    }
}
