using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Generators;

namespace BookBaazar.Domain.Entities
{
    public class Users
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Temp_Password { get; set; } =string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsVendor { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public bool IsTemp { get; set; } = false;
        public bool isActive { get; set; } = true;
    }
}
