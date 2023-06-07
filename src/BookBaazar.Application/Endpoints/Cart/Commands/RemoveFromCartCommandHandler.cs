using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Cart;
using MediatR;

namespace BookBaazar.Application.Endpoints.Cart.Commands
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, bool>
    {
        private readonly ICartService _cartService;
        public RemoveFromCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<bool> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            bool isRemoved = await _cartService.RemoveFromCart(request.item);
            if (isRemoved)
            {
                return true;
            }
            return false;
        }

    }
}
