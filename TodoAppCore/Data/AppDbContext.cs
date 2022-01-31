using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoAppCore.Entities;

namespace TodoAppCore.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Todo> Todos { get; set; }

    }
}
