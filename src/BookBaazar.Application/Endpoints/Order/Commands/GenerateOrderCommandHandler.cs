using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Order;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Commands
{
    public class GenerateOrderCommandHandler : IRequestHandler<GenerateOrderCommand,Orders>
    {
        public readonly IOrderService _orderService;
        public GenerateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
            
        }
        public async Task<Orders> Handle(GenerateOrderCommand request, CancellationToken cancellationToken)
        {
            Orders newOrder =await  _orderService.GenerateOrder(request.userId, request.order);
            if (newOrder == null)
            {
                return null;
            }
            return newOrder;
        }
    }
}
