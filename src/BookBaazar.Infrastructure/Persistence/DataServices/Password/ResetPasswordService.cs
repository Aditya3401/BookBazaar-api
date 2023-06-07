using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.Password;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Password;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookBaazar.Infrastructure.Persistence.DataServices.Password
{
    public class ResetPasswordService : IResetPasswordService
    {
        private readonly BookBazaarDbContext _dbcontext;
        public ResetPasswordService(BookBazaarDbContext dbcontext)
        {
            _dbcontext = dbcontext;
 
        }

        public async Task<bool> PasswordReset(string useremail,[FromBody] ResetPassword resetPassword)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Email == useremail);
            if(user == null)
            {
                return false;
            }
            else if(user.IsTemp)
            {
                bool comp = string.Equals(resetPassword.Password, resetPassword.ConfirmPassword);
                if (comp)
                {
                    user.Password=BCrypt.Net.BCrypt.HashPassword(resetPassword.Password);
                    user.IsTemp = false;
                    user.Temp_Password = null;
                    _dbcontext.Users.Update(user);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
            
        }

        
    }
}
