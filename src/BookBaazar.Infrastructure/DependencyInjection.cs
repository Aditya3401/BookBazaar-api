using System.Text.RegularExpressions;
using BookBaazar.Application.AWS;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Admin;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Book;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Cart;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Mail;
using BookBaazar.Infrastructure.Persistence.DataServices.Mail;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Order;
using BookBaazar.Application.Interfaces.Persistence.DataServices.User;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Vendor;
using BookBaazar.Application.Interfaces.Services;
using BookBaazar.Application.Models;
using BookBaazar.Infrastructure.Persistence.DataServices.Admin;
using BookBaazar.Infrastructure.Persistence.DataServices.Book;
using BookBaazar.Infrastructure.Persistence.DataServices.Cart;
using BookBaazar.Infrastructure.Persistence.DataServices.Order;
using BookBaazar.Infrastructure.Persistence.DataServices.User;
using BookBaazar.Infrastructure.Persistence.DataServices.Vendor;
using BookBaazar.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Password;
using BookBaazar.Infrastructure.Persistence.DataServices.Password;

namespace BookBaazar.Infrastructure;

public static class DependencyInjection
{
    private static readonly Regex InterfacePattern = new Regex("I(?:.+)DataService", RegexOptions.Compiled);

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        (from c in typeof(Application.DependencyInjection).Assembly.GetTypes()
         where c.IsInterface && InterfacePattern.IsMatch(c.Name)
         from i in typeof(DependencyInjection).Assembly.GetTypes()
         where c.IsAssignableFrom(i)
         select new
         {
             Contract = c,
             Implementation = i
         }).ToList()
        .ForEach(x => services.AddScoped(x.Contract, x.Implementation));

        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddTransient<IMailService, MailService>();
        services.AddScoped<IResetPasswordService, ResetPasswordService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IVendorService,VendorService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IBookService, BookService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));
        services.AddHttpContextAccessor();
        services.AddMediatR(typeof(UserService).Assembly);
       


        return services;
    }
}
