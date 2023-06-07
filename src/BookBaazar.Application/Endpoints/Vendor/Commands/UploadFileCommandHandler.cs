using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Vendor;
using MediatR;

namespace BookBaazar.Application.Endpoints.Vendor.Commands
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, bool>
    {
        public readonly IVendorService _vendorService;
        public UploadFileCommandHandler(IVendorService vendorService)
        {
            _vendorService = vendorService;
            
        }
        public async  Task<bool> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            bool isuploaded = await _vendorService.UploadFile(request.file, request.userId);
            return isuploaded;
        }
    }
}
