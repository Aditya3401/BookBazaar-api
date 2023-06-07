using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Queries
{
    public class GetParticularOrderQuery : IRequest<Orders>
    {
        public string orderId { get; set; }
    }
}
