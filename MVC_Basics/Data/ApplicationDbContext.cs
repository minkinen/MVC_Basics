using Microsoft.EntityFrameworkCore;
using MVC_Basics.Models;

namespace MVC_Basics.Data
{

    //  A database must be created through Entity Framework and connected to corresponding models in the C# code.
    //  Data should be persistent between executions of the program.
    // .NET 6.0 - Connect to SQL Server with Entity Framework Core
    // https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connect to SQL server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //  Use seeding to some extent.
            modelbuilder.Entity<Person>().HasData(new Person { Id = 1001, Name = "Anna Annasdotter", PhoneNumber = "08-888888", City = "Stockholm" });
            modelbuilder.Entity<Person>().HasData(new Person { Id = 1002, Name = "Bertil Bertilsson", PhoneNumber = "031-313131", City = "Göteborg" });
            modelbuilder.Entity<Person>().HasData(new Person { Id = 1003, Name = "Carl Carlsson", PhoneNumber = "040-404040", City = "Malmö" });
        }
    }
}
