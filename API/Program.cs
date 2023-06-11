
using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
 builder.Services.AddDbContext<LawerDataContext>(options => {
     options.UseSqlServer(builder.Configuration.GetConnectionString("conString"));
 });
builder.Services.AddCors();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthorization();

app.MapControllers();

app.Run();
