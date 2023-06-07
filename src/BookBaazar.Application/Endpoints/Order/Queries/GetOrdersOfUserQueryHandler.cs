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
    public class GetOrdersOfUserQueryHandler : IRequestHandler<GetOrdersOfUserQuery, List<Orders>>
    {
        private readonly IOrderService _orderService;
        public GetOrdersOfUserQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<List<Orders>> Handle(GetOrdersOfUserQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrdersOfUser(request.userId);
            return orders;
        }
    }
}
