using API.Handlers;
using API.Models;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<JwtTokenHandler>();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!
.Replace("$HOST", builder.Configuration["Database:Host"])
.Replace("$PORT", builder.Configuration["Database:Port"])
.Replace("$DATABASE", builder.Configuration["Database:Database"])
.Replace("$USERNAME", builder.Configuration["Database:Username"])
.Replace("$PASSWORD", builder.Configuration["Database:Password"]);
builder.Services.AddDbContext<ShopListContext>(
    options => options.UseNpgsql(connectionString)
);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Root}/{action=Index}"
);

app.Run();
public partial class Program { }
