using Microsoft.EntityFrameworkCore;

namespace API.Models;

internal class ShopListContext(DbContextOptions<ShopListContext> options) : DbContext(options)
{
    public DbSet<Login> Logins { get; set; }
}