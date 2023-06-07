using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.User;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.User.Commands
{
    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, Users>
    {
        private readonly IUserService _userService;
        public UserRegistrationCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Users> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            Users newUser = await _userService.RegisterUser(request.UserDTO);
            return newUser;
        }
    }
}
