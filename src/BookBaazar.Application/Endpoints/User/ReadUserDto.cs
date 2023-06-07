using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Application.Endpoints.User
{
    public class ReadUserDto
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsVendor { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public bool isActive { get; set; } = false;
    }
}
