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
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, bool>
    {
        private readonly IOrderService _orderService;
        public CancelOrderCommandHandler(IOrderService orderService)
        {

            _orderService = orderService;   
        }

        public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            bool iscanceled = await _orderService.CancelOrder(request.orderId);
            return iscanceled;  
        }

    }
}
