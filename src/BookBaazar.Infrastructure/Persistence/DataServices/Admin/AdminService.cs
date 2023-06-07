using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookBaazar.Application.Endpoints.User;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Admin;
using BookBaazar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookBaazar.Infrastructure.Persistence.DataServices.Admin
{
    public class AdminService : IAdminService
    {
        private readonly BookBazaarDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminService(BookBazaarDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> UpdateUser(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return false; 
            }
            if (user.isActive)
            {
                user.isActive = false;
            }
            else
            {
                user.isActive = true;
            }
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user.isActive;
        }

        public async Task<ReadUserDto> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == id);
            var readuser = _mapper.Map<ReadUserDto>(user);
            return readuser;
        }

        public async Task<List<ReadUserDto>> GetUsers()
        {
            var userList = await _dbContext.Users.Where(u => u.IsAdmin == false).ToListAsync();
            var users = _mapper.Map<List<ReadUserDto>>(userList);
            return users;
        }
    }
}
