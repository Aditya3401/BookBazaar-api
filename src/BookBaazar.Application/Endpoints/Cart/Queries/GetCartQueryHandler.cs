using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Cart;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Cart.Queries
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, List<BookCartReadDto>>
    {
        private readonly ICartService _cartService;
        public GetCartQueryHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<List<BookCartReadDto>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartService.GetCart(request.userId);
            return cart;
            
        }
    }
}
