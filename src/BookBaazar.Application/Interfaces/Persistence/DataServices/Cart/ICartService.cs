using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.Cart;
using BookBaazar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookBaazar.Application.Interfaces.Persistence.DataServices.Cart
{
    public interface ICartService
    {
        Task<Carts> DecreaseFromCart([FromBody] CartsDto item);
        Task<List<BookCartReadDto>> GetCart(Guid userId );
        Task<Carts> AddToCart(CartsDto item);
        Task<bool> RemoveFromCart([FromBody] CartsDto item);


    }
}
