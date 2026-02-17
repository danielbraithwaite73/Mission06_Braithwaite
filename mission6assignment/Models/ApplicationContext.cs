using Microsoft.EntityFrameworkCore;

namespace Mission06_Braithwaite.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Application> Movies { get; set; }
    }
}
