using Microsoft.EntityFrameworkCore;
using MVC_Basics.Models;

namespace MVC_Basics.Data
{

    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<Person>()
                .HasOne(p => p.City)
                .WithMany(c => c.People)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelbuilder.Entity<City>()
                .HasOne(ci => ci.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(ci => ci.CountryId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelbuilder.Entity<Country>().HasData(new Country { Id = -1, CountryName = "Denmark" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = -2, CountryName = "Norway" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = -3, CountryName = "Sweden" });

            modelbuilder.Entity<City>().HasData(new City { Id = -1, CityName = "Copenhagen", CountryId = -1 });
            modelbuilder.Entity<City>().HasData(new City { Id = -2, CityName = "Aarhus", CountryId = -1 });
            modelbuilder.Entity<City>().HasData(new City { Id = -3, CityName = "Odense", CountryId = -1 });
            modelbuilder.Entity<City>().HasData(new City { Id = -4, CityName = "Oslo", CountryId = -2 });
            modelbuilder.Entity<City>().HasData(new City { Id = -5, CityName = "Bergen", CountryId = -2 });
            modelbuilder.Entity<City>().HasData(new City { Id = -6, CityName = "Stavanger", CountryId = -2 });
            modelbuilder.Entity<City>().HasData(new City { Id = -7, CityName = "Stockholm", CountryId = -3 });
            modelbuilder.Entity<City>().HasData(new City { Id = -8, CityName = "Gothenburg", CountryId = -3 });
            modelbuilder.Entity<City>().HasData(new City { Id = -9, CityName = "Malmo", CountryId = -3 });

            modelbuilder.Entity<Person>().HasData(new Person { Id = -1, Name = "Anders Andersen", PhoneNumber = "30-293723", CityId = -1 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -2, Name = "Bernt Berntsen", PhoneNumber = "71-242427", CityId = -2 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -3, Name = "Chris Christiansen", PhoneNumber = "27-747247", CityId = -3 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -4, Name = "Alsine Alsvik", PhoneNumber = "2-468642", CityId = -4 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -5, Name = "Bjarne Bergesen", PhoneNumber = "5-324150", CityId = -5 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -6, Name = "Karin Carlsdotter", PhoneNumber = "51-515151", CityId = -6 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -7, Name = "Anna Annasdotter", PhoneNumber = "08-888888", CityId = -7 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -8, Name = "Bertil Bertilsson", PhoneNumber = "031-313131", CityId = -8 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -9, Name = "Carl Carlsson", PhoneNumber = "040-404040", CityId = -9 });

        }
    }
}
