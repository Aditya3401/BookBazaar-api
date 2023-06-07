using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Domain.Entities
{
    public class Orders
    {
        public string OrderID { get; set; }
        public Guid UserID { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; } = "Confirmed";
        public string Address { get; set; } = string.Empty;
        public string City { get; set; }=string.Empty;
        public string State { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string? TransactionId { get; set;} = string.Empty;
    }
}
