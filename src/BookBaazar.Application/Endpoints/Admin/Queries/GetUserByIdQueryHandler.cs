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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ReadUserDto>
    {
        private readonly IAdminService _adminService;
        public GetUserByIdQueryHandler(IAdminService adminService)
        {
            _adminService = adminService;
        } 

        public async Task<ReadUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _adminService.GetUserById(request.userId);
            return users;
        }
    }
}
