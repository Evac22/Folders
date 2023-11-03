using Folders.Models;
using Microsoft.EntityFrameworkCore;

namespace Folders.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Folder> Folders { get; set; }
    }
}
