using Microsoft.EntityFrameworkCore;
using UserSystem_xUnitTest.Api.Models;

namespace UserSystem_xUnitTest.Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
