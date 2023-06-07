using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookBaazar.Application.Endpoints.User;
using BookBaazar.Application.Interfaces.Persistence.DataServices.User;
using BookBaazar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookBaazar.Infrastructure.Persistence.DataServices.User
{
    public class UserService : IUserService
    {
        private readonly BookBazaarDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(BookBazaarDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Users> RegisterUser(RegisterUserDto userDTO)
        {
            userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            Users newUser = _mapper.Map<Users>(userDTO);
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> IsEmailExists(string email)
        {
            // Check if the email already exists in the database
            bool emailExists = await _dbContext.Users.AnyAsync(u => u.Email == email);
            if(!emailExists)
            {
                return false;
            }
            return emailExists;
        }

        public async Task<Users> LoginUser(LoginUserDto userDTO)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userDTO.Email);

            if(user == null)
            {
                return null;
            }
            
            if (user.IsTemp)
            {
                var isvalid2= BCrypt.Net.BCrypt.Verify(userDTO.Password, user.Temp_Password);
                if (isvalid2)
                {
                    // Mapping User to UserDTO
                    Users authUser = _mapper.Map<Users>(user);
                    return authUser;
                }
            }
            else
            {
                var isvalid = BCrypt.Net.BCrypt.Verify(userDTO.Password, user.Password);
                if (isvalid)
                {
                    // Mapping User to UserDTO
                    Users authUser = _mapper.Map<Users>(user);
                    return authUser;
                }

            }
            
            return null;
        }
    }
}
