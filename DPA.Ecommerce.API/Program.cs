using DPA.Ecommerce.DOMAIN.Core.Interfaces;
using DPA.Ecommerce.DOMAIN.Core.Services;
using DPA.Ecommerce.DOMAIN.Infrastructure.Data;
using DPA.Ecommerce.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var connectionString = _config.GetConnectionString("DeveloperConnection");
builder.Services.AddDbContext<StoreDbueContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
