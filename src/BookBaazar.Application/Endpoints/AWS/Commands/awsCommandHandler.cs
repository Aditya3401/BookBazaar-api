using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.AWS;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Vendor;
using MediatR;

namespace BookBaazar.Application.Endpoints.AWS.Commands
{
    public class awsCommandHandler : IRequestHandler<awsCommand, S3Response>
    {
        private readonly IStorageService _storageService;
        public awsCommandHandler(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public Task<S3Response> Handle(awsCommand request, CancellationToken cancellationToken)
        {
            var response = _storageService.UploadFileAsync(request.s3Obj, request.cred);
            return response;
        }
    }
}
