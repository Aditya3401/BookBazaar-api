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
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Carts>
    {
        private readonly ICartService _cartService;
        public AddToCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Carts> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartService.AddToCart(request.item);
            return cart;
            
        }
    }
}
