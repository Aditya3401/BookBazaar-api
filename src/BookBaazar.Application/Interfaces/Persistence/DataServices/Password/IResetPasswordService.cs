using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.ForgotPassword;
using BookBaazar.Application.Endpoints.Password;
using Microsoft.AspNetCore.Mvc;

namespace BookBaazar.Application.Interfaces.Persistence.DataServices.Password
{
    public interface IResetPasswordService
    {
        Task<bool>PasswordReset(string useremail,[FromBody] ResetPassword resetPassword);
        

    }
}
