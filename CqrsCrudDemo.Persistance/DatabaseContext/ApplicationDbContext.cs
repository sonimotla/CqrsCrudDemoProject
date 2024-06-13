using CqrsCrudDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CqrsCrudDemo.Application.Interfaces;
namespace CqrsCrudDemo.Persistance.DatabaseContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();

        }

    }
}
