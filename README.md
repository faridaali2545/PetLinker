# PetLinker
PetLinker is a web application developed using ASP.NET Core MVC. It aims to provide a platform for pet enthusiasts to connect, share information, and manage pet-related data efficiently.​

Features
User Management: Register, log in, and manage user profiles.

Pet Listings: Add, view, and manage pet profiles.

Search Functionality: Search for pets based on various criteria.

Responsive Design: Optimized for various devices and screen sizes.​

Technologies Used
Framework: ASP.NET Core MVC

Language: C#

Database: Entity Framework Core with SQL Server

Frontend: Razor Views, HTML5, CSS3, JavaScript​

Getting Started
Prerequisites
.NET 6 SDK

SQL Server

Visual Studio 2022 or any preferred IDE

Installation
Clone the repository:
git clone https://github.com/faridaali2545/PetLinker.git
cd PetLinker
Restore NuGet packages:

dotnet restore
Apply Migrations and Update Database:

dotnet ef database update
Run the application:
dotnet run
Access the application:

Navigate to https://localhost:5001 in your web browser.

Project Structure
Controllers/: Handles incoming HTTP requests and returns responses.

Models/: Defines the data structures and business logic.

Views/: Contains Razor views for rendering HTML content.

wwwroot/: Serves static files like CSS, JavaScript, and images.

Data/: Contains the database context and seed data.

Migrations/: Holds Entity Framework Core migration files.

appsettings.json: Configuration settings for the application.
