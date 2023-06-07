using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.User;
using MediatR;

namespace BookBaazar.Application.Endpoints.User.Queries
{
    public class CheckEmailExistsQueryHandler : IRequestHandler<CheckEmailExistsQuery, bool>
    {
        private readonly IUserService _userService;
        public CheckEmailExistsQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(CheckEmailExistsQuery request, CancellationToken cancellationToken)
        {
            bool emailExists = await _userService.IsEmailExists(request.Email);
            return emailExists;
        }
    }
}
