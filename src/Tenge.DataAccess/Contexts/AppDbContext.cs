using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Tenge.Domain.Entities;
using Tenge.Domain.Enums;

namespace Tenge.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed User
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@example.com",
                Password = "$2a$12$1mKXg7pTk..WAWEEdiFZr.F7mF2K7zMkCxcIuAgKqtUzMv70ikQvm", // Ensure this is a hashed password
                Role = UserRole.Admin
            });

        // Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Books" },
            new Category { Id = 2, Name = "Coins" },
            new Category { Id = 3, Name = "Stamps" });

        // Seed Assets
        modelBuilder.Entity<Asset>().HasData(
            new Asset { Id = 1, Name = "To Kill a Mockingbird Cover", Path = @"Pictures\Coin (1).jpeg" },
            new Asset { Id = 2, Name = "1984 Cover", Path = @"Pictures\Coin (2).jpeg" },
            new Asset { Id = 3, Name = "Ancient Roman Coin", Path = @"Pictures\Coin (3).jpeg" },
            new Asset { Id = 4, Name = "Medieval English Coin", Path = @"Pictures\Coin (4).jpeg" },
            new Asset { Id = 5, Name = "Pride and Prejudice Cover", Path = @"Pictures\Coin (5).jpeg" },
            new Asset { Id = 6, Name = "Moby Dick Cover", Path = @"Pictures\Coin (6).jpeg" },
            new Asset { Id = 7, Name = "Great Expectations Cover", Path = @"Pictures\Coin (7).jpeg" },
            new Asset { Id = 8, Name = "War and Peace Cover", Path = @"Pictures\Coin (8).jpeg" },
            new Asset { Id = 9, Name = "Ulysses Cover", Path = @"Pictures\Coin (9).jpeg" },
            new Asset { Id = 10, Name = "The Odyssey Cover", Path = @"Pictures\Book (1).jpeg" },
            new Asset { Id = 11, Name = "Coin 11 Image", Path = @"Pictures\Book (1).jpeg" },
            new Asset { Id = 12, Name = "Coin 12 Image", Path = @"Pictures\Book (2).jpeg" },
            new Asset { Id = 13, Name = "Coin 13 Image", Path = @"Pictures\Book (3).jpeg" },
            new Asset { Id = 14, Name = "Coin 14 Image", Path = @"Pictures\Book (4).jpeg" },
            new Asset { Id = 15, Name = "Coin 15 Image", Path = @"Pictures\Book (5).jpeg" },
            new Asset { Id = 16, Name = "Coin 16 Image", Path = @"Pictures\Book (6).jpeg" },
            new Asset { Id = 17, Name = "Coin 16 Image", Path = @"Pictures\Stamp (1).jpeg" },
            new Asset { Id = 18, Name = "Coin 16 Image", Path = @"Pictures\Stamp (2).jpeg" },
            new Asset { Id = 19, Name = "Coin 16 Image", Path = @"Pictures\Stamp (3).jpeg" },
            new Asset { Id = 20, Name = "Coin 16 Image", Path = @"Pictures\Stamp (4).jpeg" },
            new Asset { Id = 21, Name = "Coin 16 Image", Path = @"Pictures\Stamp (5).jpeg" });

        // Seed Collections
        modelBuilder.Entity<Collection>().HasData(
            new Collection
            {
                Id = 1,
                Name = "Fiction Books Collection",
                Description = "A collection of classic fiction books",
                PictureId = 11,
                UserId = 1,
                CategoryId = 1,
                CustomString1 = "Shelf A",
                CustomDate1 = "Published Year"
            },
            new Collection
            {
                Id = 2,
                Name = "Historical Coins Collection",
                Description = "A collection of ancient historical coins",
                PictureId = 2,
                UserId = 1,
                CategoryId = 2,
                CustomString2 = "Drawer B",
                CustomDate1 = "Discovery Year"
            },
            new Collection
            {
                Id = 3,
                Name = "Classic Stamps Collection",
                Description = "A collection of rare classic stamps",
                PictureId = 19,
                UserId = 1,
                CategoryId = 3,
                CustomString1 = "Album C",
                CustomDate1 = "Year of Issue"
            },
            new Collection
            {
                Id = 4,
                Name = "Modern Books Collection",
                Description = "A collection of contemporary novels",
                PictureId = 14,
                UserId = 1,
                CategoryId = 1,
                CustomString1 = "Bookshelf D",
                CustomDate1 = "Publication Year"
            },
            new Collection
            {
                Id = 5,
                Name = "Rare Coins Collection",
                Description = "A collection of rare and valuable coins",
                PictureId = 1,
                UserId = 1,
                CategoryId = 2,
                CustomString2 = "Display Case E",
                CustomDate1 = "Minting Year"
            });

        // Seed Items with detailed values
        modelBuilder.Entity<Item>().HasData(
            // Items for Fiction Books Collection
            new Item
            {
                Id = 1,
                Name = "To Kill a Mockingbird",
                Description = "A novel by Harper Lee published in 1960",
                CollectionId = 1,
                PictureId = 16,
                CustomString1Value = "Harper Lee",
                CustomString3Value = "Classic",
                CustomDate1Value = new DateTime(1960, 7, 11)
            },
            new Item
            {
                Id = 2,
                Name = "1984",
                Description = "A novel by George Orwell published in 1949",
                CollectionId = 1,
                PictureId = 15,
                CustomString1Value = "George Orwell",
                CustomString3Value = "Dystopian",
                CustomDate1Value = new DateTime(1949, 6, 8)
            },
            new Item
            {
                Id = 3,
                Name = "Pride and Prejudice",
                Description = "A novel by Jane Austen published in 1813",
                CollectionId = 1,
                PictureId = 14,
                CustomString1Value = "Jane Austen",
                CustomString3Value = "Romance",
                CustomDate1Value = new DateTime(1813, 1, 28)
            },
            new Item
            {
                Id = 4,
                Name = "Moby Dick",
                Description = "A novel by Herman Melville published in 1851",
                CollectionId = 1,
                PictureId = 13,
                CustomString1Value = "Herman Melville",
                CustomString3Value = "Adventure",
                CustomDate1Value = new DateTime(1851, 10, 18)
            },
            new Item
            {
                Id = 5,
                Name = "Great Expectations",
                Description = "A novel by Charles Dickens published in 1861",
                CollectionId = 1,
                PictureId = 12,
                CustomString1Value = "Charles Dickens",
                CustomString3Value = "Drama",
                CustomDate1Value = new DateTime(1861, 8, 1)
            },

            // Items for Historical Coins Collection
            new Item
            {
                Id = 6,
                Name = "Ancient Roman Coin",
                Description = "A coin from the Roman Empire",
                CollectionId = 2,
                PictureId = 3,
                CustomString1Value = "Roman Empire",
                CustomString2Value = "Bronze",
                CustomDate1Value = new DateTime(1999, 1, 1)
            },
            new Item
            {
                Id = 7,
                Name = "Medieval English Coin",
                Description = "A coin from medieval England",
                CollectionId = 2,
                PictureId = 4,
                CustomString1Value = "England",
                CustomString2Value = "Silver",
                CustomDate1Value = new DateTime(1888, 1, 1)
            },
            new Item
            {
                Id = 8,
                Name = "Ancient Greek Coin",
                Description = "A coin from ancient Greece",
                CollectionId = 2,
                PictureId = 5,
                CustomString1Value = "Greece",
                CustomString2Value = "Gold",
                CustomDate1Value = new DateTime(1987, 1, 1)
            },
            new Item
            {
                Id = 9,
                Name = "Byzantine Coin",
                Description = "A coin from the Byzantine Empire",
                CollectionId = 2,
                PictureId = 6,
                CustomString1Value = "Byzantine Empire",
                CustomString2Value = "Gold",
                CustomDate1Value = new DateTime(1999, 1, 1)
            },
            new Item
            {
                Id = 10,
                Name = "Viking Coin",
                Description = "A coin from the Viking Age",
                CollectionId = 2,
                PictureId = 7,
                CustomString1Value = "Viking Age",
                CustomString2Value = "Silver",
                CustomDate1Value = new DateTime(1899, 1, 1)
            },

            // Items for Classic Stamps Collection
            new Item
            {
                Id = 11,
                Name = "Penny Black",
                Description = "A postage stamp issued in the United Kingdom in 1840",
                CollectionId = 3,
                PictureId = 18,
                CustomString1Value = "United Kingdom",
                CustomString3Value = "Postage Stamp",
                CustomDate1Value = new DateTime(1840, 5, 6)
            },
            new Item
            {
                Id = 12,
                Name = "Inverted Jenny",
                Description = "A United States postage stamp with an airplane printed upside-down",
                CollectionId = 3,
                PictureId = 17,
                CustomString1Value = "United States",
                CustomString3Value = "Postage Stamp",
                CustomDate1Value = new DateTime(1918, 5, 10)
            },
            new Item
            {
                Id = 13,
                Name = "British Guiana 1c Magenta",
                Description = "One of the rarest postage stamps in the world",
                CollectionId = 3,
                PictureId = 18,
                CustomString1Value = "British Guiana",
                CustomString3Value = "Postage Stamp",
                CustomDate1Value = new DateTime(1856, 1, 1)
            },

            // Items for Modern Books Collection
            new Item
            {
                Id = 14,
                Name = "Harry Potter and the Philosopher's Stone",
                Description = "A novel by J.K. Rowling published in 1997",
                CollectionId = 4,
                PictureId = 12,
                CustomString1Value = "J.K. Rowling",
                CustomString3Value = "Fantasy",
                CustomDate1Value = new DateTime(1997, 6, 26)
            },
            new Item
            {
                Id = 15,
                Name = "The Da Vinci Code",
                Description = "A novel by Dan Brown published in 2003",
                CollectionId = 4,
                PictureId = 16,
                CustomString1Value = "Dan Brown",
                CustomString3Value = "Mystery",
                CustomDate1Value = new DateTime(2003, 3, 18)
            },

            // Items for Rare Coins Collection
            new Item
            {
                Id = 16,
                Name = "Double Eagle",
                Description = "A twenty-dollar gold coin of the United States minted in 1933",
                CollectionId = 5,
                PictureId = 2,
                CustomString1Value = "United States",
                CustomString2Value = "Gold",
                CustomDate1Value = new DateTime(1933, 1, 1)
            },
            new Item
            {
                Id = 17,
                Name = "Brasher Doubloon",
                Description = "An American gold coin produced by Ephraim Brasher in 1787",
                CollectionId = 5,
                PictureId = 3,
                CustomString1Value = "United States",
                CustomString2Value = "Gold",
                CustomDate1Value = new DateTime(1787, 1, 1)
            },
            new Item
            {
                Id = 18,
                Name = "Flowing Hair Dollar",
                Description = "An American silver dollar coin issued in 1794 and 1795",
                CollectionId = 5,
                PictureId = 9,
                CustomString1Value = "United States",
                CustomString2Value = "Silver",
                CustomDate1Value = new DateTime(1794, 1, 1)
            }
    );
    }



    public DbSet<Asset> Assets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }
}
