using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.ForgotPassword;
using MediatR;

namespace BookBaazar.Application.Endpoints.Mail.Commands
{
    public class SendMailAsyncCommand:IRequest<bool>
    {
        public ForgotPasswordDto forgotPasswordDto { get; set; } 
    }
}
