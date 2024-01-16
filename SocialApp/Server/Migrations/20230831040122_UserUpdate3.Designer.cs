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
    [Migration("20230831040122_UserUpdate3")]
    partial class UserUpdate3
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

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique()
                        .HasFilter("[EventId] IS NOT NULL");

                    b.ToTable("Addresses");
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
                            CreatedDate = new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7419),
                            Deleted = false,
                            Description = "Join or host social gatherings and parties at home.",
                            Name = "Home Gatherings and Parties",
                            Url = "parties",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7424),
                            Deleted = false,
                            Description = "Participate in activities focused on wellness and self-care.",
                            Name = "Wellness and Self-Care",
                            Url = "wellness",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7426),
                            Deleted = false,
                            Description = "Engage in events aimed at personal education and growth.",
                            Name = "Education and Growth",
                            Url = "education",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7427),
                            Deleted = false,
                            Description = "Experience various foods and cultural activities.",
                            Name = "Food and Culture",
                            Url = "food",
                            Visible = true
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7429),
                            Deleted = false,
                            Description = "Contribute to social causes and get engaged in community activities.",
                            Name = "Social Impact and Community Engagement",
                            Url = "community",
                            Visible = true
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7430),
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

                    b.Property<int>("AttendeeCount")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CurrencyCode")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
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
                        .HasColumnType("nvarchar(max)");

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
                            AttendeeCount = 0,
                            CategoryId = 1,
                            CurrencyCode = "SEK",
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
                            AttendeeCount = 0,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "To do yoga online for anti-aging, health, healing, stress management and workplace productivity. An elite team of teachers from Thailand, Bali, Washington DC and Costa Rica will help you on your way to achieving your goals. We also will hold yoga retreats in exotic place around the world.",
                            EndDate = new DateTime(2024, 8, 2, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Featured = true,
                            HostId = 1,
                            ImageUrl = "https://i.pinimg.com/564x/f7/28/96/f72896cd838b7c4d2db0fdc19b6d2d40.jpg",
                            LocationId = 1,
                            MaxAttendees = 50,
                            PageUrl = "events/200002",
                            Price = 0.00m,
                            StartDate = new DateTime(2024, 8, 2, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Yoga in the Park",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            AttendeeCount = 0,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "Want to stay up-to-date on the latest AI technologies? Do you want to learn from and collaborate with other programmers? If so, then this group is for you! We meet regularly at a local cafe to discuss and learn about new programming technologies. We welcome programmers of all skill levels and interests.",
                            EndDate = new DateTime(2024, 8, 3, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Featured = true,
                            HostId = 1,
                            ImageUrl = "https://i.pinimg.com/564x/c9/2d/2d/c92d2d693a0b50d620beb2340b76b51f.jpg",
                            LocationId = 3,
                            MaxAttendees = 10,
                            PageUrl = "events/200003",
                            Price = 0.00m,
                            StartDate = new DateTime(2024, 8, 3, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "AI Coding in Bangkok",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            AttendeeCount = 0,
                            CategoryId = 4,
                            CurrencyCode = "USD",
                            Deleted = false,
                            Description = "Do you love to cook or want to have a first unforgettable experience of cooking? Come and join us. We are a group of foodie who want to cook what we eat. We would pick all good ingredients by ourselves and cook them in fun and friendly atmosphere!",
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
                            AttendeeCount = 0,
                            CategoryId = 5,
                            CurrencyCode = "EUR",
                            Deleted = false,
                            Description = "This group is open to anyone and everyone who is interested in dancing. You may be a professional dancer or never danced before, everyone is welcome, even if you have two left feet. The idea is to create a platform for all types of dancers to come together, share their passion, inspire each-other and feel the divine pleasure of dancing. If you are someone who appreciate dance, would like to try dancing, dance enthusiast, learning to dance, trained dancer, dance instructor, performer please join us. It doesn't matter which dance you know or you are interested in. When you join, please send us a message why you thought of joining us and may be if you already have dance experience and would like to share it with us. We could organize workshops, gatherings, performances, charity and etc...",
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
                            AttendeeCount = 0,
                            CategoryId = 4,
                            CurrencyCode = "EUR",
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

            modelBuilder.Entity("SocialApp.Shared.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("ProfileId")
                        .IsUnique()
                        .HasFilter("[ProfileId] IS NOT NULL");

                    b.ToTable("Images");
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileImageId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AttendeeCount")
                        .HasColumnType("int");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReservationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialRequest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
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

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocationId")
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

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("LocationId");

                    b.HasIndex("ProfileId")
                        .IsUnique()
                        .HasFilter("[ProfileId] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Blocked = false,
                            CreatedDate = new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(6366),
                            Deleted = false,
                            Email = "larsson.christoffer@gmail.com",
                            LastActive = new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(6368),
                            Name = "Christoffer Larsson",
                            PasswordHash = new byte[] { 10, 99, 49, 83, 58, 190, 13, 26, 17, 42, 20, 117, 145, 180, 207, 193, 181, 96, 103, 64, 158, 173, 57, 14, 229, 216, 86, 98, 241, 240, 87, 34, 18, 114, 54, 77, 133, 124, 140, 161, 99, 158, 254, 233, 93, 123, 110, 142, 131, 45, 239, 42, 100, 193, 52, 22, 128, 197, 21, 185, 169, 19, 159, 181 },
                            PasswordSalt = new byte[] { 148, 15, 86, 91, 217, 156, 161, 18, 144, 110, 165, 240, 200, 40, 235, 238, 16, 123, 147, 189, 195, 162, 4, 167, 210, 162, 142, 200, 156, 247, 38, 202, 174, 138, 24, 153, 38, 41, 86, 89, 28, 42, 138, 142, 79, 116, 131, 108, 153, 185, 175, 224, 165, 178, 249, 45, 124, 80, 4, 50, 136, 81, 251, 198, 216, 217, 238, 89, 138, 72, 46, 46, 151, 120, 163, 14, 185, 158, 250, 5, 132, 164, 162, 71, 194, 121, 68, 142, 106, 158, 130, 127, 186, 74, 32, 77, 32, 245, 87, 126, 33, 129, 128, 17, 199, 188, 243, 111, 47, 88, 28, 139, 106, 187, 131, 160, 12, 53, 246, 180, 112, 103, 37, 44, 176, 108, 156, 203 },
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Address", b =>
                {
                    b.HasOne("SocialApp.Shared.Models.Event", "Event")
                        .WithOne("Address")
                        .HasForeignKey("SocialApp.Shared.Models.Address", "EventId");

                    b.Navigation("Event");
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

            modelBuilder.Entity("SocialApp.Shared.Models.Image", b =>
                {
                    b.HasOne("SocialApp.Shared.Models.Event", "Event")
                        .WithMany("Images")
                        .HasForeignKey("EventId");

                    b.HasOne("SocialApp.Shared.Models.Profile", "Profile")
                        .WithOne("ProfileImage")
                        .HasForeignKey("SocialApp.Shared.Models.Image", "ProfileId");

                    b.Navigation("Event");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Reservation", b =>
                {
                    b.HasOne("SocialApp.Shared.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialApp.Shared.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.User", b =>
                {
                    b.HasOne("SocialApp.Shared.Models.Address", "Address")
                        .WithOne("User")
                        .HasForeignKey("SocialApp.Shared.Models.User", "AddressId");

                    b.HasOne("SocialApp.Shared.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("SocialApp.Shared.Models.Profile", "Profile")
                        .WithOne("User")
                        .HasForeignKey("SocialApp.Shared.Models.User", "ProfileId");

                    b.Navigation("Address");

                    b.Navigation("Location");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Address", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Event", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("SocialApp.Shared.Models.Profile", b =>
                {
                    b.Navigation("ProfileImage");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("SocialApp.Shared.Models.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
