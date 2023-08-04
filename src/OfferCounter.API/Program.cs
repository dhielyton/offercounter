using Microsoft.EntityFrameworkCore;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.Users;
using OfferCounter.Infrastructure.Context;
using OfferCounter.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var test = builder.Configuration["ConnectionString:ConnectionDB"];
builder.Services.AddDbContext<OfferCounterContex>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:ConnectionDB"]);

});
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped<ICriptoCurrencyRepository, CriptoCurrencyRepository>();
builder.Services.AddScoped<IUserRepository, UserRespository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IUserRepository, UserRespository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferService, OfferService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
