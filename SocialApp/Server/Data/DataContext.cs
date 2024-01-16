using Microsoft.EntityFrameworkCore;
using SocialApp.Shared.Models.Tables;
using System.Security.Cryptography;
using System.Text;

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

namespace SocialApp.Server.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
            .Property(e => e.Role)
            .HasConversion<string>();


            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(p => p.UserId);
                entity.HasOne(u => u.User)
                     .WithOne(p => p.Profile)
                     .HasForeignKey<Profile>(a => a.UserId);
            });

            modelBuilder.Entity<Reservation>()
            .Property(e => e.ReservationStatus)
            .HasConversion<string>();

            modelBuilder
                .Entity<Reservation>()
                .Property(e => e.PaymentStatus)
                .HasConversion<string>();

            modelBuilder
                .Entity<Reservation>()
                .Property(e => e.CurrencyCode)
                .HasConversion<string>();

            modelBuilder
              .Entity<Event>()
              .Property(e => e.CurrencyCode)
              .HasConversion<string>();

            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    City = "New York City",
                    Country = "United States",
                    CountryCode = "US",
                    Latitude = 40.7128M,
                    Longitude = -74.0060M,
                },
                new Location
                {
                    Id = 2,
                    City = "Stockholm",
                    Country = "Sweden",
                    CountryCode = "SE",
                    Latitude = 59.3293M,
                    Longitude = 18.0686M,
                },
                new Location
                {
                    Id = 3,
                    City = "Bangkok",
                    Country = "Thailand",
                    CountryCode = "TH",
                    Latitude = 13.7563M,
                    Longitude = 100.5018M,
                },
                new Location
                {
                    Id = 4,
                    City = "Tokyo",
                    Country = "Japan",
                    CountryCode = "JP",
                    Latitude = 35.6762M,
                    Longitude = 139.6503M,
                },
                new Location
                {
                    Id = 5,
                    City = "London",
                    Country = "United Kingdom",
                    CountryCode = "GB",
                    Latitude = 51.5074M,
                    Longitude = -0.1278M,
                },
                new Location
                {
                    Id = 6,
                    City = "Paris",
                    Country = "France",
                    CountryCode = "FR",
                    Latitude = 48.8566M,
                    Longitude = 2.3522M,
                },
                new Location
                {
                    Id = 7,
                    City = "Berlin",
                    Country = "Germany",
                    CountryCode = "DE",
                    Latitude = 52.5200M,
                    Longitude = 13.4050M,
                },
                new Location
                {
                    Id = 8,
                    City = "Rome",
                    Country = "Italy",
                    CountryCode = "IT",
                    Latitude = 41.9028M,
                    Longitude = 12.4964M,
                },
                new Location
                {
                    Id = 9,
                    City = "Madrid",
                    Country = "Spain",
                    CountryCode = "ES",
                    Latitude = 40.4168M,
                    Longitude = -3.7038M,
                },
                new Location
                {
                    Id = 10,
                    City = "Singapore",
                    Country = "Singapore",
                    CountryCode = "SG",
                    Latitude = 1.3521M,
                    Longitude = 103.8198M,
                },
                new Location
                {
                    Id = 11,
                    City = "Hong Kong",
                    Country = "Hong Kong",
                    CountryCode = "HK",
                    Latitude = 22.3193M,
                    Longitude = 114.1694M,
                },
                new Location
                {
                    Id = 12,
                    City = "Dubai",
                    Country = "United Arab Emirates",
                    CountryCode = "AE",
                    Latitude = 25.2048M,
                    Longitude = 55.2708M,
                });


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "larsson.christoffer@gmail.com",
                    PasswordHash = CreatePasswordHash("1234abcd##"),
                    PasswordSalt = CreatePasswordSalt("1234abcd##"),
                    Name = "Christoffer Larsson",
                    Role = Role.Admin,
                });

            
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Dinner Party",
                    Description = "Do you love great food? Then join one of our events to have a great dinner with drinks and fun.",
                    LocationId = 2,
                    CategoryId = 1,
                    StartDate = new DateTime(2024, 8, 1, 18, 0, 0),
                    EndDate = new DateTime(2024, 8, 1, 22, 0, 0),
                    MaxAttendees = 6,
                    Price = 50,
                    CurrencyCode = CurrencyCode.SEK,
                    HostId = 1,
                    ImageUrl = "https://i.pinimg.com/564x/27/31/d1/2731d160096f7788c5ac8b970dbe609a.jpg",
                    PageUrl = $"events/{200001}"
                },
                new Event
                {
                    Id = 2,
                    Title = "Yoga in the Park",
                    Description = "To do yoga online for anti-aging, health, healing, stress management and workplace productivity. An elite team of teachers from Thailand, Bali, Washington DC and Costa Rica will help you on your way to achieving your goals. We also will hold yoga retreats in exotic place around the world.",
                    LocationId = 1,
                    CategoryId = 2,
                    StartDate = new DateTime(2024, 8, 2, 10, 0, 0),
                    EndDate = new DateTime(2024, 8, 2, 11, 0, 0),
                    MaxAttendees = 50,
                    HostId = 1,
                    ImageUrl = "https://i.pinimg.com/564x/f7/28/96/f72896cd838b7c4d2db0fdc19b6d2d40.jpg",
                    PageUrl = $"events/{200002}",
                    Featured = true
                },
                new Event
                {
                    Id = 3,
                    Title = "AI Coding in Bangkok",
                    Description = "Want to stay up-to-date on the latest AI technologies? Do you want to learn from and collaborate with other programmers? If so, then this group is for you! We meet regularly at a local cafe to discuss and learn about new programming technologies. We welcome programmers of all skill levels and interests.",
                    LocationId = 3,
                    CategoryId = 3,
                    StartDate = new DateTime(2024, 8, 3, 18, 0, 0),
                    EndDate = new DateTime(2024, 8, 3, 20, 0, 0),
                    MaxAttendees = 10,
                    HostId = 1,
                    ImageUrl = "https://i.pinimg.com/564x/c9/2d/2d/c92d2d693a0b50d620beb2340b76b51f.jpg",
                    PageUrl = $"events/{200003}",
                    Featured = true
                },
                new Event
                {
                    Id = 4,
                    Title = "Learn to Cook",
                    Description = "Do you love to cook or want to have a first unforgettable experience of cooking? Come and join us. We are a group of foodie who want to cook what we eat. We would pick all good ingredients by ourselves and cook them in fun and friendly atmosphere!",
                    LocationId = 4,
                    CategoryId = 4,
                    StartDate = new DateTime(2024, 8, 4, 18, 0, 0),
                    EndDate = new DateTime(2024, 8, 4, 20, 0, 0),
                    MaxAttendees = 10,
                    HostId = 1,
                    ImageUrl = "https://i.pinimg.com/564x/0e/6e/9e/0e6e9e2e2e2e2e2e2e2e2e2e2e2e2e2.jpg",
                    PageUrl = $"events/{200004}",
                    Price = 50,
                    CurrencyCode = CurrencyCode.USD
                    },      
                new Event
                {
                    Id = 5,
                    Title = "Let's Dance",
                    Description = "This group is open to anyone and everyone who is interested in dancing. You may be a professional dancer or never danced before, everyone is welcome, even if you have two left feet. The idea is to create a platform for all types of dancers to come together, share their passion, inspire each-other and feel the divine pleasure of dancing. If you are someone who appreciate dance, would like to try dancing, dance enthusiast, learning to dance, trained dancer, dance instructor, performer please join us. It doesn't matter which dance you know or you are interested in. When you join, please send us a message why you thought of joining us and may be if you already have dance experience and would like to share it with us. We could organize workshops, gatherings, performances, charity and etc...",
                    LocationId = 5,
                    CategoryId = 5,
                    StartDate = new DateTime(2024, 8, 5, 18, 0, 0),
                    EndDate = new DateTime(2024, 8, 5, 20, 0, 0),
                    MaxAttendees = 8,
                    HostId = 1,
                    ImageUrl = "https://i.pinimg.com/564x/3a/21/06/3a2106ca530f116bf6aadf8e3b46794d.jpg",
                    PageUrl = $"events/{200005}",
                    Price = 50,
                    CurrencyCode = CurrencyCode.EUR
                },
                new Event
                {
                    Id = 6,
                    Title = "Body Painting in Paris",
                    Description = "Artists who would like to work with painting on the human body as the canvas should join these events together with members of Naturist Association Thailand. For the artists it would be an opportunity to work on painting a group of people and for the naturists / nudists it would be a fun event to be part of. We already have regular life drawing events with sketching and painting artists.",
                    LocationId = 6,
                    CategoryId = 4,
                    StartDate = new DateTime(2024, 8, 6, 18, 0, 0),
                    EndDate = new DateTime(2024, 8, 6, 20, 0, 0),
                    MaxAttendees = 15,
                    HostId = 1,
                    ImageUrl = "https://i.pinimg.com/564x/2d/d9/b1/2dd9b1b66fa618f8e94104421a3444b7.jpg",
                    PageUrl = $"events/{200006}",
                    Price = 5,
                    CurrencyCode = CurrencyCode.EUR,
                    Featured = true
                });
            

            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "Home Gatherings and Parties",
                   Description = "Join or host social gatherings and parties at home.",
                   Url = "parties"
               },
               new Category
               {
                   Id = 2,
                   Name = "Wellness and Self-Care",
                   Description = "Participate in activities focused on wellness and self-care.",
                   Url = "wellness"
               },
               new Category
               {
                   Id = 3,
                   Name = "Education and Growth",
                   Description = "Engage in events aimed at personal education and growth.",
                   Url = "education"
               },
               new Category
               {
                   Id = 4,
                   Name = "Food and Culture",
                   Description = "Experience various foods and cultural activities.",
                   Url = "food"
               },
               new Category
               {
                   Id = 5,
                   Name = "Social Impact and Community Engagement",
                   Description = "Contribute to social causes and get engaged in community activities.",
                   Url = "community"
               },
               new Category
               {
                   Id = 6,
                   Name = "Adventure and Exploration",
                   Description = "Embark on adventures and explore new places and experiences.",
                   Url = "adventure"
               });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<EventSeries> EventSeries { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<EventMessage> EventMessages { get; set; }



        private byte[] CreatePasswordHash(string password)
        {
            var passwordHash = new byte[256 / 8];
            using (var hmac = new HMACSHA512()) // HMACSHA512 is a disposable class
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return passwordHash;
        }

        private byte[] CreatePasswordSalt(string password)
        {
            var passwordSalt = new byte[128 / 8];
            using (var hmac = new HMACSHA512()) // HMACSHA512 is a disposable class
            {
                passwordSalt = hmac.Key;
            }
            return passwordSalt;
        }


    }




}
