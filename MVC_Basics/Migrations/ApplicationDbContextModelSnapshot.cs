﻿// <auto-generated />
using MVC_Basics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Basics.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVC_Basics.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CityName = "Copenhagen",
                            CountryId = -1
                        },
                        new
                        {
                            Id = -2,
                            CityName = "Aarhus",
                            CountryId = -1
                        },
                        new
                        {
                            Id = -3,
                            CityName = "Odense",
                            CountryId = -1
                        },
                        new
                        {
                            Id = -4,
                            CityName = "Oslo",
                            CountryId = -2
                        },
                        new
                        {
                            Id = -5,
                            CityName = "Bergen",
                            CountryId = -2
                        },
                        new
                        {
                            Id = -6,
                            CityName = "Stavanger",
                            CountryId = -2
                        },
                        new
                        {
                            Id = -7,
                            CityName = "Stockholm",
                            CountryId = -3
                        },
                        new
                        {
                            Id = -8,
                            CityName = "Gothenburg",
                            CountryId = -3
                        },
                        new
                        {
                            Id = -9,
                            CityName = "Malmo",
                            CountryId = -3
                        });
                });

            modelBuilder.Entity("MVC_Basics.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CountryName = "Denmark"
                        },
                        new
                        {
                            Id = -2,
                            CountryName = "Norway"
                        },
                        new
                        {
                            Id = -3,
                            CountryName = "Sweden"
                        });
                });

            modelBuilder.Entity("MVC_Basics.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CityId = -1,
                            Name = "Anders Andersen",
                            PhoneNumber = "30-293723"
                        },
                        new
                        {
                            Id = -2,
                            CityId = -2,
                            Name = "Bernt Berntsen",
                            PhoneNumber = "71-242427"
                        },
                        new
                        {
                            Id = -3,
                            CityId = -3,
                            Name = "Chris Christiansen",
                            PhoneNumber = "27-747247"
                        },
                        new
                        {
                            Id = -4,
                            CityId = -4,
                            Name = "Alsine Alsvik",
                            PhoneNumber = "2-468642"
                        },
                        new
                        {
                            Id = -5,
                            CityId = -5,
                            Name = "Bjarne Bergesen",
                            PhoneNumber = "5-324150"
                        },
                        new
                        {
                            Id = -6,
                            CityId = -6,
                            Name = "Karin Carlsdotter",
                            PhoneNumber = "51-515151"
                        },
                        new
                        {
                            Id = -7,
                            CityId = -7,
                            Name = "Anna Annasdotter",
                            PhoneNumber = "08-888888"
                        },
                        new
                        {
                            Id = -8,
                            CityId = -8,
                            Name = "Bertil Bertilsson",
                            PhoneNumber = "031-313131"
                        },
                        new
                        {
                            Id = -9,
                            CityId = -9,
                            Name = "Carl Carlsson",
                            PhoneNumber = "040-404040"
                        });
                });

            modelBuilder.Entity("MVC_Basics.Models.City", b =>
                {
                    b.HasOne("MVC_Basics.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MVC_Basics.Models.Person", b =>
                {
                    b.HasOne("MVC_Basics.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("MVC_Basics.Models.City", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("MVC_Basics.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
