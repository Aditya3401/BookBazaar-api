using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Admin;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Vendor;
using MediatR;

namespace BookBaazar.Application.Endpoints.Vendor.Commands
{
    public class StatusBookCommandHandler : IRequestHandler<StatusBookCommand, bool>
    {
        private readonly IVendorService _vendorService;
        public StatusBookCommandHandler(IVendorService vendorService)
        {
            _vendorService = vendorService;

        }
        public async Task<bool> Handle(StatusBookCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _vendorService.StatusBook(request.bookId);
            return isDeleted;
        }
    }
}
