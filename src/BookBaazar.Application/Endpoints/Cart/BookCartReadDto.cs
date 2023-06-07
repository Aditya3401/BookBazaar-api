using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBaazar.Application.Endpoints.Cart
{
    public class BookCartReadDto
    {
        public Guid BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStore { get; set; } 
        public int? QuantityInCart{ get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string BookImage { get; set; } = string.Empty;
        public Guid UserID { get; set; }
        public Guid CategoryID { get; set; }
        [Range(0, 5, ErrorMessage = "Enter value greater than 0 and less than 5")]
        public decimal Rating { get; set; }
        public bool isActive { get; set; } = true;
    }
}
