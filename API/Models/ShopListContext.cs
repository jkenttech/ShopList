using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class ShopListContext(DbContextOptions<ShopListContext> options) : DbContext(options)
{
    public DbSet<Login> Logins { get; set; }
    public DbSet<User> Users { get; set; }
}