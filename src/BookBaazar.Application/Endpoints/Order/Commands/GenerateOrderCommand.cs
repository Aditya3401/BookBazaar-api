using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Commands
{
    public class GenerateOrderCommand:IRequest<Orders>
    {
        public Guid userId { get; set; }
        public OrderDto order { get; set; }
    }
}
