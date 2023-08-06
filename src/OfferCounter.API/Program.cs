using Microsoft.EntityFrameworkCore;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.Users;
using OfferCounter.Infrastructure.Context;
using OfferCounter.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using OfferCounter.API.Seed;
using OfferCounter.API.Filter;
using OfferCounter.API.Service.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.OperationFilter<UserHeaderParameter>());

builder.Services.AddDbContext<OfferCounterContex>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:ConnectionDB"]);
      

});



builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<OfferCreatedDomainEvent>());
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped<ICriptoCurrencyRepository, CriptoCurrencyRepository>();
builder.Services.AddScoped<IUserRepository, UserRespository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IUserRepository, UserRespository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();
await OfferCounterContextSeed.SeedAsync(app);


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
