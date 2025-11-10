using restaurent_api.Data;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<restaurent_api.Data.AppDbContext>(options => options.UseSqlite("Data Source=restaurent.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Learning (Foods Api)", 
        Version = "v1", 
        Description = "--", 
        Contact = new OpenApiContact
        {
            Name = "Islam Hossain",
            Email = "mislamhn@gmail.com",
            Url = new Uri("https://github.com/islam2718/dfoods-asp-core-api.git")
        }
    });
});

builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();    
}

app.UseHttpsRedirection();
app.Run();
