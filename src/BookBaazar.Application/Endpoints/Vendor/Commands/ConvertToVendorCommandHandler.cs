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
    public class ConvertToVendorCommandHandler : IRequestHandler<ConvertToVendorCommand, bool>
    {
        private readonly IVendorService _vendorService;
        public ConvertToVendorCommandHandler(IVendorService vendorService)
        {
            _vendorService = vendorService;
            
        }
        public async Task<bool> Handle(ConvertToVendorCommand request, CancellationToken cancellationToken)
        {
            var isconverted = await _vendorService.ConvertToVendor(request.userId);
            return isconverted;

        }
    }
}
