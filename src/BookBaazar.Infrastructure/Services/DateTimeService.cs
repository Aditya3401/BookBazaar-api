using System.Diagnostics.CodeAnalysis;
using BookBaazar.Application.Interfaces.Services;

namespace BookBaazar.Infrastructure.Services;

[ExcludeFromCodeCoverage]
public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}

