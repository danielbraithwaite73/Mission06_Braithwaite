using Microsoft.EntityFrameworkCore;

namespace Mission06_Braithwaite.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        //What is happening here is that we are creating a constructor for the ApplicationContext class that takes in DbContextOptions of type ApplicationContext.
        //This allows us to configure the database connection and other options when we create an instance of the ApplicationContext class.
        //The base(options) call is passing these options to the base DbContext class,
        //which will handle the actual setup of the database context based on those options.

        public DbSet<Application> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
