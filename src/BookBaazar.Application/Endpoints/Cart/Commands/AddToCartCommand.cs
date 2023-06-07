using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BookBaazar.Domain.Entities;

namespace BookBaazar.Application.Endpoints.Cart.Commands
{
    public class AddToCartCommand:IRequest<Carts>
    {
        public CartsDto item { get; set; }
    }
}
