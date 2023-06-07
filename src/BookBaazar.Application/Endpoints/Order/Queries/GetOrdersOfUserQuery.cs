using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Order.Queries
{
    public class GetOrdersOfUserQuery : IRequest<List<Orders>>
    {
        public Guid userId { get; set; }
    }
}
