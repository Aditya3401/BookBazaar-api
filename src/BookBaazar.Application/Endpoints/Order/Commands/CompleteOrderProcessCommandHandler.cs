using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Order;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Commands
{
    public class CompleteOrderProcessCommandHandler : IRequestHandler<CompleteOrderProcessCommand, string>
    {
        public readonly IOrderService _orderService;
        public CompleteOrderProcessCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public Task<string> Handle(CompleteOrderProcessCommand request, CancellationToken cancellationToken)
        {
            var response = _orderService.CompleteOrderProcess(request.httpContextAccessor);
            return response;
        }
    }
}
