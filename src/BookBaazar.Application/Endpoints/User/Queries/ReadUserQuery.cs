using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.User.Queries
{
    public class ReadUserQuery : IRequest<Users>
    {
        public LoginUserDto loginUser { get; set; }
    }
}
