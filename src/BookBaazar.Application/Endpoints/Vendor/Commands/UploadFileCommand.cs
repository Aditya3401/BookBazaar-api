using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookBaazar.Application.Endpoints.Vendor.Commands
{
    public class UploadFileCommand:IRequest<bool>
    {
        public  Guid userId { get; set; }
        public IFormFile file { get; set; } 
    }
}
