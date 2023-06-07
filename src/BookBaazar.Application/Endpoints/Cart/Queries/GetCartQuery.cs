using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Cart.Queries
{
    public class GetCartQuery : IRequest<List<BookCartReadDto>>
    {
        public Guid userId {get;set;}

    }
}
