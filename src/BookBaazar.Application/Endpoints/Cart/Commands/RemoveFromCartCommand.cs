using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookBaazar.Application.Endpoints.Cart.Commands
{
    public class RemoveFromCartCommand:IRequest<bool>
    {
        public CartsDto item { get; set; }
    }
}
