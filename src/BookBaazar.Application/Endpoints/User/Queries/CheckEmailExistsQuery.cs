using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookBaazar.Application.Endpoints.User.Queries
{
    public class CheckEmailExistsQuery : IRequest<bool>
    {
        public string Email { get; set; }
    }

}
