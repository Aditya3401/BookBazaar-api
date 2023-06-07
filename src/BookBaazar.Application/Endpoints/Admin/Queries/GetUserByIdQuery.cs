using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.User;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Admin.Queries
{
    public class GetUserByIdQuery : IRequest<ReadUserDto>
    {
        public Guid userId { get; set; }
    }
}
