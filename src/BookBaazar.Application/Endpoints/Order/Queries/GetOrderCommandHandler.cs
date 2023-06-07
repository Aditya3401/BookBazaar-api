using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Order;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Queries
{
    public class GetOrderCommandHandler : IRequestHandler<GetOrderCommand, List<OrderBooksRead>>
    {
        private readonly IOrderService _orderService;
        public GetOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<List<OrderBooksRead>> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        {
            List<OrderBooksRead> result =await _orderService.GetOrder(request.orderId);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
