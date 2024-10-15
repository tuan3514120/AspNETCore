using Microsoft.EntityFrameworkCore;
using Shopping.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shopping.Insfrastructure
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}

