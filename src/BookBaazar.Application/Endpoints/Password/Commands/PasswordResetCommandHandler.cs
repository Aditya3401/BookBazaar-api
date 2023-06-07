using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Password;
using MediatR;

namespace BookBaazar.Application.Endpoints.Password.Commands
{
    public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommand, bool>
    {
        private readonly IResetPasswordService _resetPasswordService;
        public PasswordResetCommandHandler(IResetPasswordService resetPasswordService)
        {
            _resetPasswordService = resetPasswordService;
            
        }
        public async Task<bool> Handle(PasswordResetCommand request, CancellationToken cancellationToken)
        {
            return await _resetPasswordService.PasswordReset(request.useremail, request.resetpassword);
        }
    }
}
