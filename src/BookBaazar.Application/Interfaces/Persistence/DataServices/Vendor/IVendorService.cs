using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.Book;
using BookBaazar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookBaazar.Application.Interfaces.Persistence.DataServices.Vendor
{
    public interface IVendorService
    {
        Task<bool> UploadFile(IFormFile file, Guid userId);
        Task<bool> ConvertToVendor(Guid userId);
        Task<List<Books>> GetVendor_Published_Books(Guid userId);
        Task<Books> PublishBook(Guid userId, BookDto bookDto);
        Task<bool> StatusBook(Guid bookId);
    }
}
