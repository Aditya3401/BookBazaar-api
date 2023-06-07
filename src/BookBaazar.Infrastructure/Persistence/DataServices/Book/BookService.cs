using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Book;
using BookBaazar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookBaazar.Infrastructure.Persistence.DataServices.Book
{
    public class BookService : IBookService
    {
        private readonly BookBazaarDbContext _dbContext;
        public BookService(BookBazaarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Books>> FilterBooksByCategory(Guid id)
        {
            var books = await _dbContext.Books.Where(b => b.CategoryID == id && b.isActive == true).ToListAsync();
            return books;
        }

        public async Task<Books> GetBookById(Guid id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookID == id);
            return book;
        }

        public async Task<List<Books>> GetBooks()
        {
            var books = await _dbContext.Books.Where(b => b.isActive == true).ToListAsync();
            return books;
        }

        public async Task<List<Books>> GetTrendingBooks()
        {
            var trendingBooks = await _dbContext.Books.Where(b => b.Rating > 4.0M && b.isActive == true).ToListAsync();
            return trendingBooks;
        }
    }
}
