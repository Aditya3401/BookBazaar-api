using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Commands
{
    public class CancelOrderCommand:IRequest<bool>
    {
        public string orderId { get; set; }


    }
}
