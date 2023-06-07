using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.User;
using BookBaazar.Domain.Entities;

namespace BookBaazar.Application.Interfaces.Persistence.DataServices.Admin
{
    public interface IAdminService
    {
        Task<List<ReadUserDto>> GetUsers();
        Task<ReadUserDto> GetUserById(Guid id);
        Task<bool> UpdateUser(Guid id);
    }
}
