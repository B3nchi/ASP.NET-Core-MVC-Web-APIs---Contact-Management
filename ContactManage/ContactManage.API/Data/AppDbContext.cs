using Microsoft.EntityFrameworkCore;
using ContactManage.API.Models;

namespace ContactManage.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
