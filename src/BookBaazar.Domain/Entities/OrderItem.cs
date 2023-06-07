using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Domain.Entities
{
    public class OrderItem
    {
        public Guid OrderItemID { get; set; }
        public string OrderID { get; set; }
        public Guid BookID { get; set; }
        public int Quantity { get; set; }
    }
}
