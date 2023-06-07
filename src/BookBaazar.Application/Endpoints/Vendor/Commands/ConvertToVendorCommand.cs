using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookBaazar.Application.Endpoints.Vendor.Commands
{
    public class ConvertToVendorCommand:IRequest<bool>
    {
        public Guid userId { get; set; }
    }
}
