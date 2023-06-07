using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Admin;
using MediatR;

namespace BookBaazar.Application.Endpoints.Admin.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IAdminService _adminService;
        public UpdateUserCommandHandler(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var isUpdated = await _adminService.UpdateUser(request.userId);
            return isUpdated;
        }
    }
}
