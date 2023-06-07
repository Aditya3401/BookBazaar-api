using AutoMapper;
using BookBaazar.Application.Mapping;
using Xunit;

namespace BookBaazar.Application.Tests.Mapping;

public class PeopleProfileTests
{
    [Fact]
    public void VerifyConfiguration()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

        configuration.AssertConfigurationIsValid();
    }
}
