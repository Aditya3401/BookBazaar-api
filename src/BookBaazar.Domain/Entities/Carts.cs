using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Domain.Entities
{
    public class Carts
    {
        public Guid CartID { get; set; }
        public Guid BookID { get; set; }
        public Guid UserID { get; set; }
        public int QuantityInCart { get; set; } = 1;
    }

}
