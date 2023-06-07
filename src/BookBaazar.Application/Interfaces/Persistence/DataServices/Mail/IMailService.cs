using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.ForgotPassword;
using BookBaazar.Application.Endpoints.Mail;
using Microsoft.AspNetCore.Mvc;

namespace BookBaazar.Application.Interfaces.Persistence.DataServices.Mail
{
    public interface IMailService
    {
        Task<bool> SendMailAsync([FromBody] ForgotPasswordDto forgotPasswordDto);
    }
}
