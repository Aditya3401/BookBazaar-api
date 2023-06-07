using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.Order;
using BookBaazar.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBaazar.Application.Interfaces.Persistence.DataServices.Order
{
    public interface IOrderService
    {
        Task<Orders> GenerateOrder(Guid userId, [FromBody] OrderDto orderDto);
        Task<bool> CancelOrder(string orderId);
        Task<List<OrderBooksRead>> GetOrder(string orderId);
        Task<string> CompleteOrderProcess([FromServices] IHttpContextAccessor httpContextAccessor);
        Task<List<Orders>> GetOrdersOfUser(Guid userId);
        Task<Orders> GetParticularOrder(string orderId);
    }
}
