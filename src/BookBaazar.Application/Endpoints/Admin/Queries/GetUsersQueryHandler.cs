using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.User;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Admin;
using BookBaazar.Domain.Entities;
using MediatR;

namespace BookBaazar.Application.Endpoints.Admin.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<ReadUserDto>>
    {
        private readonly IAdminService _adminService;
        public GetUsersQueryHandler(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<List<ReadUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _adminService.GetUsers();
            return users;
        }
    }
}
