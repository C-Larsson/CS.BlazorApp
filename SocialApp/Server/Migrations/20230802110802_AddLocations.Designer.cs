﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialApp.Server.Data;

#nullable disable

namespace SocialApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230802110802_AddLocations")]
    partial class AddLocations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SocialApp.Shared.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adressess");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(238),
                            Deleted = false,
                            Description = "Join or host social gatherings and parties at home.",
                            Name = "Home Gatherings and Parties",
                            Url = "parties",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(243),
                            Deleted = false,
                            Description = "Participate in activities focused on wellness and self-care.",
                            Name = "Wellness and Self-Care",
                            Url = "wellnes",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(244),
                            Deleted = false,
                            Description = "Engage in events aimed at personal education and growth.",
                            Name = "Education and Growth",
                            Url = "education",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(246),
                            Deleted = false,
                            Description = "Experience various foods and cultural activities.",
                            Name = "Food and Culture",
                            Url = "food",
                            Visible = true
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(247),
                            Deleted = false,
                            Description = "Contribute to social causes and get engaged in community activities.",
                            Name = "Social Impact and Community Engagement",
                            Url = "community",
                            Visible = true
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(249),
                            Deleted = false,
                            Description = "Embark on adventures and explore new places and experiences.",
                            Name = "Adventure and Exploration",
                            Url = "adventure",
                            Visible = true
                        });
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventSeriesId")
                        .HasColumnType("int");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<int>("MaxAttendees")
                        .HasColumnType("int");

                    b.Property<string>("PageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventSeriesId");

                    b.HasIndex("LocationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.EventSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<int>("MaxAttendees")
                        .HasColumnType("int");

                    b.Property<string>("PageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeriesFrequency")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.ToTable("EventSeries");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "New York City",
                            Country = "United States",
                            CountryCode = "US",
                            Latitude = 40.7128m,
                            Longitude = -74.0060m,
                            State = ""
                        },
                        new
                        {
                            Id = 2,
                            City = "Stockholm",
                            Country = "Sweden",
                            CountryCode = "SE",
                            Latitude = 59.3293m,
                            Longitude = 18.0686m,
                            State = ""
                        },
                        new
                        {
                            Id = 3,
                            City = "Bangkok",
                            Country = "Thailand",
                            CountryCode = "TH",
                            Latitude = 13.7563m,
                            Longitude = 100.5018m,
                            State = ""
                        },
                        new
                        {
                            Id = 4,
                            City = "Tokyo",
                            Country = "Japan",
                            CountryCode = "JP",
                            Latitude = 35.6762m,
                            Longitude = 139.6503m,
                            State = ""
                        },
                        new
                        {
                            Id = 5,
                            City = "London",
                            Country = "United Kingdom",
                            CountryCode = "GB",
                            Latitude = 51.5074m,
                            Longitude = -0.1278m,
                            State = ""
                        },
                        new
                        {
                            Id = 6,
                            City = "Paris",
                            Country = "France",
                            CountryCode = "FR",
                            Latitude = 48.8566m,
                            Longitude = 2.3522m,
                            State = ""
                        },
                        new
                        {
                            Id = 7,
                            City = "Berlin",
                            Country = "Germany",
                            CountryCode = "DE",
                            Latitude = 52.5200m,
                            Longitude = 13.4050m,
                            State = ""
                        },
                        new
                        {
                            Id = 8,
                            City = "Rome",
                            Country = "Italy",
                            CountryCode = "IT",
                            Latitude = 41.9028m,
                            Longitude = 12.4964m,
                            State = ""
                        },
                        new
                        {
                            Id = 9,
                            City = "Madrid",
                            Country = "Spain",
                            CountryCode = "ES",
                            Latitude = 40.4168m,
                            Longitude = -3.7038m,
                            State = ""
                        },
                        new
                        {
                            Id = 10,
                            City = "Singapore",
                            Country = "Singapore",
                            CountryCode = "SG",
                            Latitude = 1.3521m,
                            Longitude = 103.8198m,
                            State = ""
                        },
                        new
                        {
                            Id = 11,
                            City = "Hong Kong",
                            Country = "Hong Kong",
                            CountryCode = "HK",
                            Latitude = 22.3193m,
                            Longitude = 114.1694m,
                            State = ""
                        },
                        new
                        {
                            Id = 12,
                            City = "Dubai",
                            Country = "United Arab Emirates",
                            CountryCode = "AE",
                            Latitude = 25.2048m,
                            Longitude = 55.2708m,
                            State = ""
                        });
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Revoked")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("EventId");

                    b.HasIndex("LocationId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 2, 11, 8, 2, 146, DateTimeKind.Utc).AddTicks(9388),
                            Email = "larsson.christoffer@gmail.com",
                            LastActive = new DateTime(2023, 8, 2, 11, 8, 2, 146, DateTimeKind.Utc).AddTicks(9390),
                            LocationId = 2,
                            Name = "Christoffer Larsson",
                            PasswordHash = new byte[] { 22, 20, 238, 143, 82, 84, 138, 226, 142, 17, 183, 31, 247, 25, 174, 120, 151, 196, 98, 3, 21, 239, 247, 224, 215, 7, 91, 184, 115, 145, 100, 97, 83, 253, 20, 98, 101, 12, 163, 137, 235, 51, 138, 208, 151, 114, 132, 169, 11, 7, 140, 107, 6, 227, 120, 78, 44, 75, 66, 165, 8, 239, 180, 240 },
                            PasswordSalt = new byte[] { 92, 194, 195, 212, 73, 227, 141, 96, 89, 23, 73, 107, 175, 239, 55, 142, 82, 226, 233, 36, 254, 82, 249, 199, 98, 78, 130, 53, 143, 124, 131, 171, 119, 201, 160, 31, 73, 215, 77, 29, 18, 142, 41, 158, 36, 131, 38, 41, 89, 82, 22, 201, 183, 10, 89, 44, 104, 215, 99, 73, 29, 59, 171, 156, 129, 180, 65, 151, 181, 19, 161, 196, 60, 81, 142, 147, 252, 166, 129, 14, 223, 228, 149, 48, 247, 105, 1, 221, 119, 234, 193, 234, 90, 220, 222, 55, 7, 243, 123, 87, 136, 22, 38, 245, 165, 83, 121, 219, 92, 206, 30, 247, 244, 47, 4, 158, 154, 96, 100, 102, 159, 170, 32, 72, 216, 163, 5, 190 },
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Event", b =>
                {
                    b.HasOne("SocialApp.Shared.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Shared.Models.EventSeries", "EventSeries")
                        .WithMany()
                        .HasForeignKey("EventSeriesId");

                    b.HasOne("SocialApp.Shared.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("EventSeries");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.EventSeries", b =>
                {
                    b.HasOne("SocialApp.Shared.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Shared.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Shared.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Category");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Profile", b =>
                {
                    b.HasOne("SocialApp.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.User", b =>
                {
                    b.HasOne("SocialApp.Shared.Models.Event", null)
                        .WithMany("Participants")
                        .HasForeignKey("EventId");

                    b.HasOne("SocialApp.Shared.Models.Location", "location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("location");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Event", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
