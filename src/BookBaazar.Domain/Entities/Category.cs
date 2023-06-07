using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Domain.Entities
{
    public class Category
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
