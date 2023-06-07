using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Application.Endpoints.Cart
{
    public class CartsDto
    {
        public Guid UserID { get; set; }
        public Guid BookID { get; set; }

    }
}
