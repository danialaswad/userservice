using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
            // nothing
        }
        
        public DbSet<User> Users { get; set; }
    }
}