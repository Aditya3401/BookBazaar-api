using System.Reflection;
using BookBaazar.Application.Interfaces;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookBaazar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(typeof(IRequestValidator<>), typeof(RequestValidator<>));

        var thisAssembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(thisAssembly);
        services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(thisAssembly));
        services.AddMediatR(thisAssembly);

        return services;
    }
}
