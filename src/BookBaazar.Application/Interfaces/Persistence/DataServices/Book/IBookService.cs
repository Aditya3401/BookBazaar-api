using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Domain.Entities;

namespace BookBaazar.Application.Interfaces.Persistence.DataServices.Book
{
    public interface IBookService
    {
        Task<List<Books>> GetBooks();
        Task<Books> GetBookById(Guid id);
        Task<List<Books>> GetTrendingBooks();
        Task<List<Books>> FilterBooksByCategory(Guid id);
    }
}
