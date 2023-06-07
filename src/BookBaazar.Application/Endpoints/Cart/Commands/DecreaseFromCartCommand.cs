using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Cart.Commands
{
    public class DecreaseFromCartCommand: IRequest<Carts>
    {
        public CartsDto item { get; set; }  
    }
}
