using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookBaazar.Application.Endpoints.Admin.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid userId { get; set; }
    }
}
