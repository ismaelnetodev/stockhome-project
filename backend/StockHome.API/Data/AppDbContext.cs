using Microsoft.EntityFrameworkCore;
using StockHome.API.Models;

namespace StockHome.API.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Category> Categories => Set<Category>();

    }
}
