using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using AutoMapper;
using BookBaazar.Application.AWS;
using BookBaazar.Application.Endpoints.AWS.Commands;
using BookBaazar.Application.Endpoints.Book;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Vendor;
using BookBaazar.Domain.Entities;
using BookBaazar.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookBaazar.Infrastructure.Persistence.DataServices.Vendor
{
    
    public class VendorService : IVendorService
    {
        public static IDictionary<Guid, string> url = new Dictionary<Guid, string>();
        private readonly BookBazaarDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        public VendorService(BookBazaarDbContext dbContext, IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
            
        }

        public async Task<bool> ConvertToVendor(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == id);
            if (user == null)
            {
                return false;
            }
            user.IsVendor = true;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user.IsVendor;
        }

        public async Task<bool> StatusBook(Guid bookId)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b=>b.BookID==bookId);
            if (book.isActive)
            {
                book.isActive = false;
            }
            else
            {
                book.isActive = true;

            }
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            return book.isActive;
        }

        public async Task<List<Books>> GetVendor_Published_Books(Guid id)
        {
            var books = await _dbContext.Books.Where(b => b.UserID == id).ToListAsync();
            return books;
        }

        public async Task<Books> PublishBook(Guid userId, BookDto bookDto)
        {
            Books book=_mapper.Map<Books>(bookDto);
            book.BookImage = url[userId];
            book.UserID = userId;
            _dbContext.Books.Add(book);
             await _dbContext.SaveChangesAsync();
            url.Remove(userId);
            return book;
        }

        public async Task<bool> UploadFile(IFormFile file, Guid userId)
        {
            bool isuploaded = false;
            //Process the file

            await using var memoryStr = new MemoryStream();
            await file.CopyToAsync(memoryStr);

            var fileExt = Path.GetExtension(file.FileName);
            var objName = $"{Guid.NewGuid()}.{fileExt}";

            var s3Obj = new S3Object()
            {
                BucketName = "bookbazaar",
                InputStream = memoryStr,
                Name = objName
            };

            var cred = new AwsCredentials()
            {
                AwsKey = _configuration["AwsConfiguration:AWSAccessKey"],
                AwsSecretKey = _configuration["AwsConfiguration:AWSSecretKey"]
            };

            var result = await _storageService.UploadFileAsync(s3Obj, cred);

            //get url request
            var Imageurl = $"https://bookbazaar.s3.amazonaws.com/{objName}";
            url.Add(userId, Imageurl);
            isuploaded = true;
            return isuploaded;

        }

    }
}
