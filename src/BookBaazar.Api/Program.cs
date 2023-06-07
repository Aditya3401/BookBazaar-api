using BookBaazar.Api.Services;
using BookBaazar.Application;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Mail;
using BookBaazar.Application.Interfaces.Services;
using BookBaazar.Application.Models;
using BookBaazar.Infrastructure;
using BookBaazar.Infrastructure.Persistence.DataServices.Mail;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

// Configure Services
var builder = WebApplication.CreateBuilder(args);
// TODO: Remove this line if you want to return the Server header
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

builder.Services.AddSingleton(builder.Configuration);

// Adds in Application dependencies
builder.Services.AddApplication(builder.Configuration);
// Adds in Infrastructure dependencies
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;
});

builder.Services.AddScoped<IPrincipalService, PrincipalService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<BookBazaarDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookBaazar.Api", Version = "v1" });
});

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Configure Application
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookBaazar.Api v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.Use(async (httpContext, next) =>
{
    var apiMode = httpContext.Request.Path.StartsWithSegments("/api");
    if (apiMode)
    {
        httpContext.Request.Headers[HeaderNames.XRequestedWith] = "XMLHttpRequest";
    }
    await next();
});

app.UseCors("corspolicy");

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
    endpoints.MapControllers();
});

app.Run();
