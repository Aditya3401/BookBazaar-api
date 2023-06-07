using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Application.Endpoints.Order
{
    public class OrderBooksRead
    {
        public string orderId { get; set; }
        public Guid BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public int QuantityInOrder { get; set; }
        public string ISBN { get; set; }
        public string BookImage { get; set; }
        public Guid CategoryID { get; set; }
        [Range(0, 5, ErrorMessage = "Enter value greater than 0 and less than 5")]
        public decimal Rating { get; set; }

    }
}
