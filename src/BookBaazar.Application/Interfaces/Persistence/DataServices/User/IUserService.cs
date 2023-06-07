using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.User;
using BookBaazar.Domain.Entities;

namespace BookBaazar.Application.Interfaces.Persistence.DataServices.User
{
    public interface IUserService
    {
        Task<Users> RegisterUser(RegisterUserDto userDTO);
        Task<bool> IsEmailExists(string email);
        Task<Users> LoginUser(LoginUserDto userDTO);
    }
}
