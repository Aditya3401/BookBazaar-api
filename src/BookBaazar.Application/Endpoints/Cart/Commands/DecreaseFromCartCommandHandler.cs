using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Cart;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Cart.Commands
{
    public class DecreaseFromCartCommandHandler : IRequestHandler<DecreaseFromCartCommand, Carts>
    {
        private readonly ICartService _cartService;
        public DecreaseFromCartCommandHandler( ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<Carts> Handle(DecreaseFromCartCommand request, CancellationToken cancellationToken)
        {
            var cart=await _cartService.DecreaseFromCart(request.item);
            return cart;

        }
    }
}
