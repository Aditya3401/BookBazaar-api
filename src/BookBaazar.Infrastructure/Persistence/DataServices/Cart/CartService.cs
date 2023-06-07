using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookBaazar.Application.Endpoints.Cart;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Cart;
using BookBaazar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookBaazar.Infrastructure.Persistence.DataServices.Cart
{
    public class CartService : ICartService
    {
        private readonly BookBazaarDbContext _dbContext;
        private readonly IMapper _mapper;
        public CartService(BookBazaarDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }
        public async Task<Carts> AddToCart([FromBody]CartsDto item)
        {
            

            var cart =  await _dbContext.Carts.FirstOrDefaultAsync(c => c.UserID == item.UserID && c.BookID == item.BookID);

            //If Item does not exist
            if (cart == null)
            {
                Carts new_cart=_mapper.Map<Carts>(item);
                _dbContext.Carts.Add(new_cart);
                await _dbContext.SaveChangesAsync();
                return new_cart;
            }
            //If Item already exists
            cart.QuantityInCart = cart.QuantityInCart+ 1;
            _dbContext.Carts.Update(cart);
            await _dbContext.SaveChangesAsync(); 
            return cart;
        }

        public async Task<Carts> DecreaseFromCart([FromBody] CartsDto item)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.UserID == item.UserID && c.BookID == item.BookID);
            if (cart == null)
            {
                return null;
            }
            cart.QuantityInCart =cart.QuantityInCart - 1;
            if(cart.QuantityInCart == 0)
            {
                _dbContext.Carts.Remove(cart);
                await _dbContext.SaveChangesAsync();
                return null;
            }
            else
            {
                _dbContext.Carts.Update(cart);
            }      
            await _dbContext.SaveChangesAsync();
            return cart;
        }

        public async Task<List<BookCartReadDto>> GetCart(Guid userId)
        {
            List<BookCartReadDto> book = new List<BookCartReadDto>();
            var cart = await _dbContext.Carts.Where(b => b.UserID == userId).ToListAsync();
            foreach(var item in cart)
            {
                Guid id = item.BookID;
                Books b1= _dbContext.Books.FirstOrDefault(U=>U.BookID == id);
                
                var b2=_mapper.Map<BookCartReadDto>(b1);
                b2.QuantityInCart = item.QuantityInCart;
                book.Add(b2);
            }
            return book;
        }

        public async Task<bool> RemoveFromCart(CartsDto item)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.UserID == item.UserID && c.BookID == item.BookID);
            if (cart == null)
            {
                return false;
            }
            _dbContext.Carts.Remove(cart);
            await _dbContext.SaveChangesAsync();
            bool isremoved = true;
            return true;
        }
    }
}
