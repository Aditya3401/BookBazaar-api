using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Queries
{
    public class GetOrderCommand:IRequest<List<OrderBooksRead>>
    {
        public string orderId { get; set; } 
    }
}
