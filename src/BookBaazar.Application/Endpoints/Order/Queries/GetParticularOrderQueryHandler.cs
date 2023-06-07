using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Order;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Queries
{
    public class GetParticularOrderQueryHandler : IRequestHandler<GetParticularOrderQuery, Orders>
    {
        private readonly IOrderService _orderService;
        public GetParticularOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public Task<Orders> Handle(GetParticularOrderQuery request, CancellationToken cancellationToken)
        {
            var order = _orderService.GetParticularOrder(request.orderId);
            return order;
        }
    }
}
