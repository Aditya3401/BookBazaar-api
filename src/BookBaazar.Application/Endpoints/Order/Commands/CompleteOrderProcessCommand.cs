using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookBaazar.Application.Endpoints.Order.Commands
{
    public class CompleteOrderProcessCommand : IRequest<string>
    {
        public IHttpContextAccessor httpContextAccessor { get; set; }
    }
}
