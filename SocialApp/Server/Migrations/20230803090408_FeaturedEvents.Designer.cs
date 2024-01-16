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
    [Migration("20230803090408_FeaturedEvents")]
    partial class FeaturedEvents
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
                            CreatedDate = new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3894),
                            Deleted = false,
                            Description = "Join or host social gatherings and parties at home.",
                            Name = "Home Gatherings and Parties",
                            Url = "parties",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3898),
                            Deleted = false,
                            Description = "Participate in activities focused on wellness and self-care.",
                            Name = "Wellness and Self-Care",
                            Url = "wellnes",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3899),
                            Deleted = false,
                            Description = "Engage in events aimed at personal education and growth.",
                            Name = "Education and Growth",
                            Url = "education",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3901),
                            Deleted = false,
                            Description = "Experience various foods and cultural activities.",
                            Name = "Food and Culture",
                            Url = "food",
                            Visible = true
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3902),
                            Deleted = false,
                            Description = "Contribute to social causes and get engaged in community activities.",
                            Name = "Social Impact and Community Engagement",
                            Url = "community",
                            Visible = true
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3904),
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

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Currency = "SEK",
                            Deleted = false,
                            Description = "Do you love great food? Then join one of our events to have a great dinner with drinks and fun.",
                            EndDate = new DateTime(2024, 8, 1, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Featured = false,
                            HostId = 1,
                            ImageUrl = "https://i.pinimg.com/564x/27/31/d1/2731d160096f7788c5ac8b970dbe609a.jpg",
                            LocationId = 2,
                            MaxAttendees = 6,
                            PageUrl = "events/200001",
                            Price = 50m,
                            StartDate = new DateTime(2024, 8, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Dinner Party",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Currency = "",
                            Deleted = false,
                            Description = "To do yoga online for anti-aging, health, healing, stress management and workplace productivity. An elite team of teachers from Thailand, Bali, Washington DC and Costa Rica will help you on your way to achieving your goals. We also will hold yoga retreats in exotic place around the world.",
                            EndDate = new DateTime(2024, 8, 2, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Featured = true,
                            HostId = 1,
                            ImageUrl = "https://i.pinimg.com/564x/f7/28/96/f72896cd838b7c4d2db0fdc19b6d2d40.jpg",
                            LocationId = 1,
                            MaxAttendees = 10,
                            PageUrl = "events/200002",
                            Price = 0m,
                            StartDate = new DateTime(2024, 8, 2, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Yoga in the Park",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Currency = "",
                            Deleted = false,
                            Description = "Want to stay up-to-date on the latest AI technologies? Do you want to learn from and collaborate with other programmers? If so, then this group is for you!\r\n\r\nWe meet regularly at a local cafe to discuss and learn about new programming technologies. We welcome programmers of all skill levels and interests.",
                            EndDate = new DateTime(2024, 8, 3, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Featured = true,
                            HostId = 1,
                            ImageUrl = "https://i.pinimg.com/564x/c9/2d/2d/c92d2d693a0b50d620beb2340b76b51f.jpg",
                            LocationId = 3,
                            MaxAttendees = 10,
                            PageUrl = "events/200003",
                            Price = 0m,
                            StartDate = new DateTime(2024, 8, 3, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "AI Coding in Bangkok",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Currency = "USD",
                            Deleted = false,
                            Description = "Do you love to cook or want to have a first unforgettable experience of cooking? Come and join us. We are a group of foodie who want to cook what we eat. We would pick all good ingredients by ourselves(NO MSG.) and cook them in fun and friendly atmosphere!",
                            EndDate = new DateTime(2024, 8, 4, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Featured = false,
                            HostId = 1,
                            ImageUrl = "https://i.pinimg.com/564x/0e/6e/9e/0e6e9e2e2e2e2e2e2e2e2e2e2e2e2e2.jpg",
                            LocationId = 4,
                            MaxAttendees = 10,
                            PageUrl = "events/200004",
                            Price = 50m,
                            StartDate = new DateTime(2024, 8, 4, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Learn to Cook",
                            Visible = true
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Currency = "GBP",
                            Deleted = false,
                            Description = "This group is open to anyone and everyone who is interested in dancing. You may be a professional dancer or never danced before, everyone is welcome, even if you have two left feet...\r\n\r\nThe idea is to create a platform for all types of dancers to come together, share their passion, inspire each-other and feel the divine pleasure of dancing...\r\n\r\nIf you are someone who appreciate dance, would like to try dancing, dance enthusiast, learning to dance, trained dancer, dance instructor, performer please join us. It doesn't matter which dance you know or you are interested in.\r\n\r\nWhen you join, please send us a message why you thought of joining us and may be if you already have dance experience and would like to share it with us. We could organize workshops, gatherings, performances, charity and etc...",
                            EndDate = new DateTime(2024, 8, 5, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Featured = false,
                            HostId = 1,
                            ImageUrl = "https://i.pinimg.com/564x/3a/21/06/3a2106ca530f116bf6aadf8e3b46794d.jpg",
                            LocationId = 5,
                            MaxAttendees = 8,
                            PageUrl = "events/200005",
                            Price = 50m,
                            StartDate = new DateTime(2024, 8, 5, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Let's Dance",
                            Visible = true
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 4,
                            Currency = "EUR",
                            Deleted = false,
                            Description = "Artists who would like to work with painting on the human body as the canvas should join these events together with members of Naturist Association Thailand. For the artists it would be an opportunity to work on painting a group of people and for the naturists / nudists it would be a fun event to be part of. We already have regular life drawing events with sketching and painting artists.",
                            EndDate = new DateTime(2024, 8, 6, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Featured = true,
                            HostId = 1,
                            ImageUrl = "https://i.pinimg.com/564x/2d/d9/b1/2dd9b1b66fa618f8e94104421a3444b7.jpg",
                            LocationId = 6,
                            MaxAttendees = 15,
                            PageUrl = "events/200006",
                            Price = 5m,
                            StartDate = new DateTime(2024, 8, 6, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Body Painting in Paris",
                            Visible = true
                        });
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "New York City",
                            Country = "United States",
                            CountryCode = "US",
                            Latitude = 40.7128m,
                            Longitude = -74.0060m
                        },
                        new
                        {
                            Id = 2,
                            City = "Stockholm",
                            Country = "Sweden",
                            CountryCode = "SE",
                            Latitude = 59.3293m,
                            Longitude = 18.0686m
                        },
                        new
                        {
                            Id = 3,
                            City = "Bangkok",
                            Country = "Thailand",
                            CountryCode = "TH",
                            Latitude = 13.7563m,
                            Longitude = 100.5018m
                        },
                        new
                        {
                            Id = 4,
                            City = "Tokyo",
                            Country = "Japan",
                            CountryCode = "JP",
                            Latitude = 35.6762m,
                            Longitude = 139.6503m
                        },
                        new
                        {
                            Id = 5,
                            City = "London",
                            Country = "United Kingdom",
                            CountryCode = "GB",
                            Latitude = 51.5074m,
                            Longitude = -0.1278m
                        },
                        new
                        {
                            Id = 6,
                            City = "Paris",
                            Country = "France",
                            CountryCode = "FR",
                            Latitude = 48.8566m,
                            Longitude = 2.3522m
                        },
                        new
                        {
                            Id = 7,
                            City = "Berlin",
                            Country = "Germany",
                            CountryCode = "DE",
                            Latitude = 52.5200m,
                            Longitude = 13.4050m
                        },
                        new
                        {
                            Id = 8,
                            City = "Rome",
                            Country = "Italy",
                            CountryCode = "IT",
                            Latitude = 41.9028m,
                            Longitude = 12.4964m
                        },
                        new
                        {
                            Id = 9,
                            City = "Madrid",
                            Country = "Spain",
                            CountryCode = "ES",
                            Latitude = 40.4168m,
                            Longitude = -3.7038m
                        },
                        new
                        {
                            Id = 10,
                            City = "Singapore",
                            Country = "Singapore",
                            CountryCode = "SG",
                            Latitude = 1.3521m,
                            Longitude = 103.8198m
                        },
                        new
                        {
                            Id = 11,
                            City = "Hong Kong",
                            Country = "Hong Kong",
                            CountryCode = "HK",
                            Latitude = 22.3193m,
                            Longitude = 114.1694m
                        },
                        new
                        {
                            Id = 12,
                            City = "Dubai",
                            Country = "United Arab Emirates",
                            CountryCode = "AE",
                            Latitude = 25.2048m,
                            Longitude = 55.2708m
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
                            CreatedDate = new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(2937),
                            Email = "larsson.christoffer@gmail.com",
                            LastActive = new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(2938),
                            LocationId = 2,
                            Name = "Christoffer Larsson",
                            PasswordHash = new byte[] { 128, 174, 89, 178, 160, 136, 217, 162, 29, 64, 172, 248, 108, 238, 227, 130, 104, 216, 253, 229, 80, 161, 239, 24, 136, 114, 16, 207, 205, 10, 221, 214, 30, 248, 121, 151, 128, 18, 40, 56, 38, 74, 228, 19, 191, 235, 42, 46, 138, 231, 1, 72, 57, 77, 42, 70, 172, 198, 245, 191, 119, 41, 87, 219 },
                            PasswordSalt = new byte[] { 52, 47, 64, 133, 71, 160, 23, 166, 194, 102, 44, 104, 59, 6, 39, 236, 94, 220, 124, 202, 8, 168, 15, 230, 222, 34, 114, 57, 162, 11, 204, 17, 43, 36, 151, 40, 246, 99, 253, 68, 62, 152, 164, 202, 225, 92, 88, 79, 186, 193, 135, 234, 87, 236, 202, 135, 46, 157, 75, 120, 62, 62, 224, 172, 134, 88, 125, 185, 50, 144, 36, 109, 21, 57, 186, 97, 160, 217, 89, 161, 195, 240, 238, 183, 141, 106, 236, 102, 178, 0, 254, 95, 87, 132, 175, 117, 219, 187, 37, 226, 206, 213, 179, 155, 136, 62, 19, 141, 234, 26, 211, 230, 219, 206, 229, 175, 231, 35, 246, 71, 77, 60, 127, 197, 110, 9, 185, 202 },
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
