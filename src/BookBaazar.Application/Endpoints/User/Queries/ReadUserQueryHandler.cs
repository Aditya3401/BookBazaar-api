using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.User;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.User.Queries
{
    public class ReadUserQueryHandler : IRequestHandler<ReadUserQuery, Users>
    {
        private readonly IUserService _userService;

        public ReadUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Users> Handle(ReadUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.LoginUser(request.loginUser);
        }
    }
}
