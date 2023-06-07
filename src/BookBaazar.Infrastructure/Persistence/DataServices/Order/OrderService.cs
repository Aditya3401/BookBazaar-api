using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using BookBaazar.Application.Endpoints.Order;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Order;
using BookBaazar.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;

namespace BookBaazar.Infrastructure.Persistence.DataServices.Order
{
    public class OrderService : IOrderService
    {   
        private readonly BookBazaarDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderService(BookBazaarDbContext bookBazaarDbContext, IMapper mapper)
        {
            _dbContext = bookBazaarDbContext;
            _mapper = mapper;   
            
        }
        // work left on cancelorder
        public async Task<bool> CancelOrder(string orderId)
        {
            bool cancelorder = false;
            var orderitem = _dbContext.OrderItems.Where(c => c.OrderID == orderId).ToList();
            foreach(var item in orderitem)
            {
                _dbContext.OrderItems.Remove(item);

            }
            
            var removeOrder = _dbContext.Orders.FirstOrDefault(c => c.OrderID == orderId);
            if (removeOrder != null)
            {
                _dbContext.Orders.Remove(removeOrder);
                cancelorder = true;
            }
            await _dbContext.SaveChangesAsync();
            return cancelorder;

        }

        public async Task<Orders> GenerateOrder(Guid userId, [FromBody] OrderDto orderDto)
        {
            Random randomObj = new Random();
            string transactionId = randomObj.Next(1000, 100000000).ToString();
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_C7P80DrdG4R3Iy", "pQTjVX2pc3mqGjA6wDclSEOC");
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", orderDto.OrderTotal * 100);
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            /*options.Add("payment_capture", "0");*/ // 1 - automatic  , 0 - manual
                                                 //options.Add("Notes", "Test Payment of Merchant");
            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();

            bool isordered = false;
            var transaction=_dbContext.Database.BeginTransaction();
            Orders newOrder = _mapper.Map<Orders>(orderDto);
            newOrder.OrderID = orderId;
            newOrder.UserID = userId;
            _dbContext.Orders.Add(newOrder);
            await _dbContext.SaveChangesAsync();

            // Retrieve cart items for the user
            var cartItems = _dbContext.Carts
                .Where(c => c.UserID == userId)
                .ToList();

            // Update book quantities and insert book information into OrderItems table
            foreach (var cartItem in cartItems)
            {
                var book = _dbContext.Books.Find(cartItem.BookID);
                if (book != null)
                {
                    //Check the quantity in cart should not be greater than the quantity in store
                    if (cartItem.QuantityInCart > book.QuantityInStore)
                    {
                        return null;
                    }

                    book.QuantityInStore -= cartItem.QuantityInCart;
               
                    var orderItem = new OrderItem
                    {
                        OrderID = orderId,
                        BookID = cartItem.BookID,
                        Quantity = cartItem.QuantityInCart
                    };
                    _dbContext.OrderItems.Add(orderItem);
                    await _dbContext.SaveChangesAsync();
                    _dbContext.Books.Update(book);
                    await _dbContext.SaveChangesAsync();
                    _dbContext.Carts.Remove(cartItem);
                    await _dbContext.SaveChangesAsync();
                } 
            }
            
            isordered = true;
            transaction.Commit();
            return newOrder;

        }

        public async Task<string> CompleteOrderProcess([FromServices] IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                Dictionary<string, string> attributes = new Dictionary<string, string>();
                var httpContext = httpContextAccessor.HttpContext;

                attributes.Add("razorpay_payment_id", httpContext.Request.Form["razorpay_payment_id"]);
                attributes.Add("razorpay_order_id", httpContext.Request.Form["razorpay_order_id"]);
                attributes.Add("razorpay_signature", httpContext.Request.Form["razorpay_signature"]);

                Orders order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderID == attributes["razorpay_order_id"]);
                order.TransactionId = attributes["razorpay_payment_id"];
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync();

                Utils.verifyPaymentSignature(attributes);

                return httpContext.Request.Form["razorpay_payment_id"];
            }
            catch (Exception)
            {
                throw;
            }
        }
    
        public async Task<List<OrderBooksRead>> GetOrder(string orderId)
        {
            List<OrderBooksRead> list_books=new List<OrderBooksRead> ();
            var order= await _dbContext.OrderItems.Where(b=>b.OrderID == orderId).ToListAsync();
            foreach(var book in order)
            {
                var item = _dbContext.Books.Find(book.BookID);
                var orderbook = _mapper.Map<OrderBooksRead>(item);
                orderbook.QuantityInOrder= book.Quantity;
                orderbook.orderId = book.OrderID;
                list_books.Add(orderbook);
            }
            if (list_books == null)
            {
                return null;
            }
            return list_books;
            
        }

        public async Task<List<Orders>> GetOrdersOfUser(Guid userId)
        {
            var orders = await _dbContext.Orders.Where(o => o.UserID == userId).ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;
        }

        public async Task<Orders> GetParticularOrder(string orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if(order == null)
            {
                return null;
            }
            return order;
        }
    }
}
