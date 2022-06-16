using _16._06Praktika.Models;
using Microsoft.EntityFrameworkCore;

namespace _16._06Praktika.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions opt):base(opt)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
