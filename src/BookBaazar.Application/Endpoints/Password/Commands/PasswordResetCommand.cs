using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookBaazar.Application.Endpoints.Password.Commands
{
    public class PasswordResetCommand:IRequest<bool>
    {
        public string useremail { get; set; }
        public ResetPassword resetpassword { get; set; }    
    }
}
