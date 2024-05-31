using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tenge.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PictureId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CustomString1 = table.Column<string>(type: "text", nullable: true),
                    CustomString2 = table.Column<string>(type: "text", nullable: true),
                    CustomString3 = table.Column<string>(type: "text", nullable: true),
                    CustomInt1 = table.Column<string>(type: "text", nullable: true),
                    CustomInt2 = table.Column<string>(type: "text", nullable: true),
                    CustomInt3 = table.Column<string>(type: "text", nullable: true),
                    CustomDate1 = table.Column<string>(type: "text", nullable: true),
                    CustomDate2 = table.Column<string>(type: "text", nullable: true),
                    CustomDate3 = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_Assets_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Collections_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collections_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CollectionId = table.Column<long>(type: "bigint", nullable: false),
                    PictureId = table.Column<long>(type: "bigint", nullable: true),
                    CustomString1Value = table.Column<string>(type: "text", nullable: true),
                    CustomString2Value = table.Column<string>(type: "text", nullable: true),
                    CustomString3Value = table.Column<string>(type: "text", nullable: true),
                    CustomInt1Value = table.Column<int>(type: "integer", nullable: true),
                    CustomInt2Value = table.Column<int>(type: "integer", nullable: true),
                    CustomInt3Value = table.Column<int>(type: "integer", nullable: true),
                    CustomDate1Value = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CustomDate2Value = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CustomDate3Value = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Assets_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "Path", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3336), 0L, null, null, false, "To Kill a Mockingbird Cover", "Pictures\\Coin (1).jpeg", null, null },
                    { 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3341), 0L, null, null, false, "1984 Cover", "Pictures\\Coin (2).jpeg", null, null },
                    { 3L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3342), 0L, null, null, false, "Ancient Roman Coin", "Pictures\\Coin (3).jpeg", null, null },
                    { 4L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3343), 0L, null, null, false, "Medieval English Coin", "Pictures\\Coin (4).jpeg", null, null },
                    { 5L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3344), 0L, null, null, false, "Pride and Prejudice Cover", "Pictures\\Coin (5).jpeg", null, null },
                    { 6L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3345), 0L, null, null, false, "Moby Dick Cover", "Pictures\\Coin (6).jpeg", null, null },
                    { 7L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3346), 0L, null, null, false, "Great Expectations Cover", "Pictures\\Coin (7).jpeg", null, null },
                    { 8L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3346), 0L, null, null, false, "War and Peace Cover", "Pictures\\Coin (8).jpeg", null, null },
                    { 9L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3347), 0L, null, null, false, "Ulysses Cover", "Pictures\\Coin (9).jpeg", null, null },
                    { 10L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3349), 0L, null, null, false, "The Odyssey Cover", "Pictures\\Book (1).jpeg", null, null },
                    { 11L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3379), 0L, null, null, false, "Coin 11 Image", "Pictures\\Book (1).jpeg", null, null },
                    { 12L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3380), 0L, null, null, false, "Coin 12 Image", "Pictures\\Book (2).jpeg", null, null },
                    { 13L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3381), 0L, null, null, false, "Coin 13 Image", "Pictures\\Book (3).jpeg", null, null },
                    { 14L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3382), 0L, null, null, false, "Coin 14 Image", "Pictures\\Book (4).jpeg", null, null },
                    { 15L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3383), 0L, null, null, false, "Coin 15 Image", "Pictures\\Book (5).jpeg", null, null },
                    { 16L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3384), 0L, null, null, false, "Coin 16 Image", "Pictures\\Book (6).jpeg", null, null },
                    { 17L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3384), 0L, null, null, false, "Coin 16 Image", "Pictures\\Stamp (1).jpeg", null, null },
                    { 18L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3385), 0L, null, null, false, "Coin 16 Image", "Pictures\\Stamp (2).jpeg", null, null },
                    { 19L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3386), 0L, null, null, false, "Coin 16 Image", "Pictures\\Stamp (3).jpeg", null, null },
                    { 20L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3387), 0L, null, null, false, "Coin 16 Image", "Pictures\\Stamp (4).jpeg", null, null },
                    { 21L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3388), 0L, null, null, false, "Coin 16 Image", "Pictures\\Stamp (5).jpeg", null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3310), 0L, null, null, false, "Books", null, null },
                    { 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3312), 0L, null, null, false, "Coins", null, null },
                    { 3L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3312), 0L, null, null, false, "Stamps", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Role", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3158), 0L, null, null, "admin@example.com", "Admin", false, "User", "$2a$12$1mKXg7pTk..WAWEEdiFZr.F7mF2K7zMkCxcIuAgKqtUzMv70ikQvm", 1, null, null });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedByUserId", "CustomDate1", "CustomDate2", "CustomDate3", "CustomInt1", "CustomInt2", "CustomInt3", "CustomString1", "CustomString2", "CustomString3", "DeletedAt", "DeletedByUserId", "Description", "IsDeleted", "Name", "PictureId", "UpdatedAt", "UpdatedByUserId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3433), 0L, "Published Year", null, null, null, null, null, "Shelf A", null, null, null, null, "A collection of classic fiction books", false, "Fiction Books Collection", 11L, null, null, 1L },
                    { 2L, 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3440), 0L, "Discovery Year", null, null, null, null, null, null, "Drawer B", null, null, null, "A collection of ancient historical coins", false, "Historical Coins Collection", 2L, null, null, 1L },
                    { 3L, 3L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3442), 0L, "Year of Issue", null, null, null, null, null, "Album C", null, null, null, null, "A collection of rare classic stamps", false, "Classic Stamps Collection", 19L, null, null, 1L },
                    { 4L, 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3444), 0L, "Publication Year", null, null, null, null, null, "Bookshelf D", null, null, null, null, "A collection of contemporary novels", false, "Modern Books Collection", 14L, null, null, 1L },
                    { 5L, 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3446), 0L, "Minting Year", null, null, null, null, null, null, "Display Case E", null, null, null, "A collection of rare and valuable coins", false, "Rare Coins Collection", 1L, null, null, 1L }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CollectionId", "CreatedAt", "CreatedByUserId", "CustomDate1Value", "CustomDate2Value", "CustomDate3Value", "CustomInt1Value", "CustomInt2Value", "CustomInt3Value", "CustomString1Value", "CustomString2Value", "CustomString3Value", "DeletedAt", "DeletedByUserId", "Description", "IsDeleted", "Name", "PictureId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3468), 0L, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Harper Lee", null, "Classic", null, null, "A novel by Harper Lee published in 1960", false, "To Kill a Mockingbird", 16L, null, null },
                    { 2L, 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3480), 0L, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "George Orwell", null, "Dystopian", null, null, "A novel by George Orwell published in 1949", false, "1984", 15L, null, null },
                    { 3L, 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3484), 0L, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Jane Austen", null, "Romance", null, null, "A novel by Jane Austen published in 1813", false, "Pride and Prejudice", 14L, null, null },
                    { 4L, 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3487), 0L, new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Herman Melville", null, "Adventure", null, null, "A novel by Herman Melville published in 1851", false, "Moby Dick", 13L, null, null },
                    { 5L, 1L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3489), 0L, new DateTime(1861, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Charles Dickens", null, "Drama", null, null, "A novel by Charles Dickens published in 1861", false, "Great Expectations", 12L, null, null },
                    { 6L, 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3490), 0L, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Roman Empire", "Bronze", null, null, null, "A coin from the Roman Empire", false, "Ancient Roman Coin", 3L, null, null },
                    { 7L, 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3493), 0L, new DateTime(1888, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "England", "Silver", null, null, null, "A coin from medieval England", false, "Medieval English Coin", 4L, null, null },
                    { 8L, 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3495), 0L, new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Greece", "Gold", null, null, null, "A coin from ancient Greece", false, "Ancient Greek Coin", 5L, null, null },
                    { 9L, 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3497), 0L, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Byzantine Empire", "Gold", null, null, null, "A coin from the Byzantine Empire", false, "Byzantine Coin", 6L, null, null },
                    { 10L, 2L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3499), 0L, new DateTime(1899, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Viking Age", "Silver", null, null, null, "A coin from the Viking Age", false, "Viking Coin", 7L, null, null },
                    { 11L, 3L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3501), 0L, new DateTime(1840, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "United Kingdom", null, "Postage Stamp", null, null, "A postage stamp issued in the United Kingdom in 1840", false, "Penny Black", 18L, null, null },
                    { 12L, 3L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3503), 0L, new DateTime(1918, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "United States", null, "Postage Stamp", null, null, "A United States postage stamp with an airplane printed upside-down", false, "Inverted Jenny", 17L, null, null },
                    { 13L, 3L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3505), 0L, new DateTime(1856, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "British Guiana", null, "Postage Stamp", null, null, "One of the rarest postage stamps in the world", false, "British Guiana 1c Magenta", 18L, null, null },
                    { 14L, 4L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3506), 0L, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "J.K. Rowling", null, "Fantasy", null, null, "A novel by J.K. Rowling published in 1997", false, "Harry Potter and the Philosopher's Stone", 12L, null, null },
                    { 15L, 4L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3552), 0L, new DateTime(2003, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Dan Brown", null, "Mystery", null, null, "A novel by Dan Brown published in 2003", false, "The Da Vinci Code", 16L, null, null },
                    { 16L, 5L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3554), 0L, new DateTime(1933, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "United States", "Gold", null, null, null, "A twenty-dollar gold coin of the United States minted in 1933", false, "Double Eagle", 2L, null, null },
                    { 17L, 5L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3556), 0L, new DateTime(1787, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "United States", "Gold", null, null, null, "An American gold coin produced by Ephraim Brasher in 1787", false, "Brasher Doubloon", 3L, null, null },
                    { 18L, 5L, new DateTime(2024, 5, 30, 18, 56, 31, 209, DateTimeKind.Utc).AddTicks(3558), 0L, new DateTime(1794, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "United States", "Silver", null, null, null, "An American silver dollar coin issued in 1794 and 1795", false, "Flowing Hair Dollar", 9L, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_PictureId",
                table: "Collections",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserId",
                table: "Collections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollectionId",
                table: "Items",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PictureId",
                table: "Items",
                column: "PictureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
