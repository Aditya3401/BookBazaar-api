using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Mail;
using MediatR;

namespace BookBaazar.Application.Endpoints.Mail.Commands
{
    public class SendMailAsyncCommandHandler : IRequestHandler<SendMailAsyncCommand, bool>
    {
        private readonly IMailService _mailService;
        public SendMailAsyncCommandHandler(IMailService mailService)
        {
            _mailService = mailService;
        }
        public async Task<bool> Handle(SendMailAsyncCommand request, CancellationToken cancellationToken)
        {
            bool result = await _mailService.SendMailAsync(request.forgotPasswordDto);
            return result;
        }
    }
}
