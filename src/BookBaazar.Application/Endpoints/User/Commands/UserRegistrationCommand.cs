using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.User.Commands
{
    public class UserRegistrationCommand : IRequest<Users>
    {
        public RegisterUserDto UserDTO { get; set; }
    }
}
