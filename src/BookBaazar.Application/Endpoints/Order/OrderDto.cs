using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Application.Endpoints.Order
{
    public class OrderDto
    {
        //public Guid UserID { get; set; }
        public decimal OrderTotal { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; }
    }
}
