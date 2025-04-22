using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetLinker.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Products = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    OpeningHours = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PaymentMethods = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetActivities",
                columns: table => new
                {
                    ActivityNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetActivities", x => x.ActivityNumber);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HealthCondition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserProfileUsername = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserProfileUsername",
                        column: x => x.UserProfileUsername,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.InsertData(
                table: "BreedInfos",
                columns: new[] { "Id", "Breed", "Description", "ImageUrl", "PetType" },
                values: new object[,]
                {
                    { 1, "Golden Retriever", "Golden Retrievers are friendly, intelligent, and devoted.", "golden_retriever.jpg", "Dog" },
                    { 2, "Bulldog", "Bulldogs are muscular, brave, and affectionate.", "bulldog.jpg", "Dog" },
                    { 3, "Labrador Retriever", "Labrador Retrievers are outgoing, even-tempered, and gentle.", "labrador_retriever.jpg", "Dog" },
                    { 4, "Persian", "Persians are calm, gentle, and make great lap cats.", "persian.jpg", "Cat" },
                    { 5, "Maine Coon", "Maine Coons are known for their large size, friendly nature, and intelligence.", "maine_coon.jpg", "Cat" },
                    { 6, "Siamese", "Siamese cats are social, vocal, and affectionate.", "siamese.jpg", "Cat" },
                    { 7, "Parrot", "Parrots are intelligent, social, and colorful.", "parrot.jpg", "Bird" },
                    { 8, "Canary", "Canaries are small, colorful, and great singers.", "canary.jpg", "Bird" },
                    { 9, "Finch", "Finches are small, active birds with colorful feathers.", "finch.jpg", "Bird" }
                });

            migrationBuilder.InsertData(
                table: "MarketPlaces",
                columns: new[] { "Id", "ContactInfo", "Description", "Location", "OpeningHours", "PaymentMethods", "Products", "StoreName" },
                values: new object[,]
                {
                    { 1, "111-222-3333", "A pet store offering a variety of pet products and accessories.", "Nasr City", "9:00 AM - 8:00 PM", "Cash, Credit Card, PayPal", "Pet food, Pet toys, Pet accessories", "Pet World" },
                    { 2, "444-555-6666", "Specialized store for pet grooming supplies and accessories.", "6th of October", "10:00 AM - 7:00 PM", "Cash, Debit Card", "Dog collars, Cat trees, Pet grooming products", "Paws & Claws" },
                    { 3, "777-888-9999", "A boutique for fashionable pet clothing and accessories.", "Tagmoa", "11:00 AM - 6:00 PM", "Cash, Credit Card", "Pet apparel, Leashes, Pet beds", "Furry Friends Boutique" },
                    { 4, "555-666-7777", "Store selling fish tanks, aquatic life supplies, and pet birds.", "Nasr City", "8:00 AM - 8:00 PM", "Cash, Credit Card", "Aquariums, Fish food, Birds cages", "The Pet Shop" },
                    { 5, "999-000-1111", "Offering a wide range of healthy products for pets.", "6th of October", "9:00 AM - 5:00 PM", "Cash, Debit Card, PayPal", "Pet food, Vitamins, Supplements", "Healthy Pets" },
                    { 6, "333-444-5555", "A one-stop shop for all your pet supply needs.", "Tagmoa", "10:00 AM - 7:00 PM", "Cash, Credit Card", "Pet cages, Pet carriers, Pet cleaning products", "Pet Supplies Hub" }
                });

            migrationBuilder.InsertData(
                table: "PetActivities",
                columns: new[] { "ActivityNumber", "ActivityName", "ActivityType", "ContactInfo", "Description", "Location" },
                values: new object[,]
                {
                    { 1, "Dog Park Meetup", "Outdoor", "123-456-7890", "A fun meetup for dogs and their owners in the park.", "Tagmoa" },
                    { 2, "Pet Grooming Workshop", "Workshop", "987-654-3210", "Learn the basics of pet grooming from professionals.", "6th of October" },
                    { 3, "Cat Show", "Exhibition", "555-123-4567", "An exhibition of different cat breeds and their owners.", "Nasr City" },
                    { 4, "Pet Playdate", "Outdoor", "222-333-4444", "A fun playdate for pets of all kinds to interact and make new friends.", "Nasr City" },
                    { 5, "Pet Wellness Check-up", "Workshop", "333-444-5555", "A workshop offering health check-ups and wellness tips for pets.", "6th of October" },
                    { 6, "Dog Agility Training", "Workshop", "444-555-6666", "A workshop focusing on agility training for dogs of all sizes.", "Tagmoa" },
                    { 7, "Pet Fashion Show", "Exhibition", "555-666-7777", "An exciting fashion show featuring pets in stylish outfits.", "Nasr City" },
                    { 8, "Exotic Pet Care Talk", "Seminar", "666-777-8888", "A seminar on how to care for exotic pets like reptiles and birds.", "6th of October" },
                    { 9, "Pet Nutrition Workshop", "Workshop", "777-888-9999", "A workshop focusing on the best nutrition practices for your pets.", "Nasr City" },
                    { 10, "Dog Walking Group", "Outdoor", "888-999-0000", "Join our group walk through the park for dogs and their owners.", "6th of October" },
                    { 11, "Pet First Aid Training", "Workshop", "999-000-1111", "Learn essential first aid skills for your pets in an emergency.", "Tagmoa" },
                    { 12, "Feline Behavior Seminar", "Seminar", "000-111-2222", "A seminar on understanding and managing common feline behaviors.", "Nasr City" },
                    { 13, "Pet-Friendly Home Design", "Workshop", "111-222-3333", "Learn how to design a pet-friendly home for your furry friends.", "6th of October" },
                    { 14, "Senior Pet Care Talk", "Seminar", "222-333-4444", "A talk about the special care needed for older pets.", "Tagmoa" },
                    { 15, "Pet Massage Class", "Workshop", "333-444-5555", "Learn the basics of massaging your pet for relaxation and health.", "Nasr City" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Breed", "Gender", "HealthCondition", "Location", "Status", "Type", "UserProfileUsername" },
                values: new object[,]
                {
                    { 1, 2, "British Shorthair", "Male", "", "Tagmoa", "Adopted", "Cat", null },
                    { 2, 1, "Golden Retriever", "Female", "", "Nasr City", "Adopted", "Dog", null },
                    { 3, 2, "Basset Hound", "Male", "", "Maadi", "Free", "Dog", null },
                    { 4, 3, "Maine Coon", "Female", "", "Zayed", "Free", "Cat", null },
                    { 5, 4, "American Shorthair", "Male", "", "Tagmoa", "Free", "Cat", null },
                    { 6, 1, "Parrot", "Female", "", "Rehab", "Free", "Bird", null }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "Description", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "2024-12-21", null, "Rania Elmorshidy", "01128394759" },
                    { 2, "2024-12-22", null, "Nada Waleed", "01234567893" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Email", "Feedback", "Password", "Status" },
                values: new object[,]
                {
                    { "Azza", "Azza@gmail.com", "", "123456", "Normal" },
                    { "Malak", "Malak@gmail.com", "Overall experiance is so good", "12345", "Adopter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserProfileUsername",
                table: "Pets",
                column: "UserProfileUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedInfos");

            migrationBuilder.DropTable(
                name: "MarketPlaces");

            migrationBuilder.DropTable(
                name: "PetActivities");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
