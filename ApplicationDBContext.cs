using PetLinker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PetLinker.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetActivity> PetActivities { get; set; }
        public DbSet<MarketPlaceEntity> MarketPlaces { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<BreedInfo> BreedInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasData(new UserProfile[] {
                    new UserProfile {Username = "Malak", Password = "12345", Email = "Malak@gmail.com" , Status = "Adopter" , Feedback = "Overall experiance is so good"},
                    new UserProfile {Username = "Azza", Password = "123456", Email = "Azza@gmail.com" , Status="Normal"}
                });

            modelBuilder.Entity<Pet>()
                .HasData(new Pet[] {
                    new Pet { Id = 1, Gender = "Male", Age = 2, Location = "Tagmoa",Type="Cat", Breed = "British Shorthair", Status = "Adopted" },
                    new Pet { Id = 2, Gender = "Female", Age = 1, Location = "Nasr City",Type="Dog", Breed = "Golden Retriever", Status = "Adopted" },
                    new Pet { Id = 3, Gender = "Male", Age = 2, Location = "Maadi",Type="Dog", Breed = "Basset Hound", Status = "Free" },
                    new Pet { Id = 4, Gender = "Female", Age = 3, Location = "Zayed",Type="Cat", Breed = "Maine Coon", Status = "Free" },
                    new Pet { Id = 5, Gender = "Male", Age = 4, Location = "Tagmoa",Type="Cat", Breed = "American Shorthair", Status = "Free" },
                    new Pet { Id = 6, Gender = "Female", Age = 1, Location = "Rehab",Type="Bird", Breed = "Parrot", Status = "Free" }
                });

            modelBuilder.Entity<PetActivity>()
                .HasData(new PetActivity[] {
                    new PetActivity{
                         ActivityNumber = 1,
                         ActivityName = "Dog Park Meetup",
                         ActivityType = "Outdoor",
                         Location = "Tagmoa",
                         Description = "A fun meetup for dogs and their owners in the park.",

                         ContactInfo = "123-456-7890" },

                    new PetActivity {
                        ActivityNumber = 2,
                        ActivityName = "Pet Grooming Workshop",
                        ActivityType = "Workshop",
                        Location = "6th of October",
                        Description = "Learn the basics of pet grooming from professionals.",

                        ContactInfo = "987-654-3210" },
                    new PetActivity
                    {
                        ActivityNumber = 3,
                        ActivityName = "Cat Show",
                        ActivityType = "Exhibition",
                        Location = "Nasr City",
                        Description = "An exhibition of different cat breeds and their owners.",

                        ContactInfo = "555-123-4567"
                    },
                    new PetActivity {
                        ActivityNumber = 4,
                        ActivityName = "Pet Playdate",
                        ActivityType = "Outdoor",
                        Location = "Nasr City",
                        Description = "A fun playdate for pets of all kinds to interact and make new friends.",

                        ContactInfo = "222-333-4444"
                    },
                    new PetActivity
                    {
                        ActivityNumber = 5,
                        ActivityName = "Pet Wellness Check-up",
                        ActivityType = "Workshop",
                        Location = "6th of October",
                        Description = "A workshop offering health check-ups and wellness tips for pets.",

                        ContactInfo = "333-444-5555"
                    },
                    new PetActivity
                    {
                        ActivityNumber = 6,
                        ActivityName = "Dog Agility Training",
                        ActivityType = "Workshop",
                        Location = "Tagmoa",
                        Description = "A workshop focusing on agility training for dogs of all sizes.",

                        ContactInfo = "444-555-6666"
                    },
                    new PetActivity {
                        ActivityNumber = 7,
                        ActivityName = "Pet Fashion Show",
                        ActivityType = "Exhibition",
                        Location = "Nasr City",
                        Description = "An exciting fashion show featuring pets in stylish outfits.",

                        ContactInfo = "555-666-7777" },
                    new PetActivity {
                        ActivityNumber = 8,
                        ActivityName = "Exotic Pet Care Talk",
                        ActivityType = "Seminar",
                        Location = "6th of October",
                        Description = "A seminar on how to care for exotic pets like reptiles and birds.",

                        ContactInfo = "666-777-8888"
                    },
                    new PetActivity {
                        ActivityNumber = 9,
                        ActivityName = "Pet Nutrition Workshop",
                        ActivityType = "Workshop",
                        Location = "Nasr City",
                        Description = "A workshop focusing on the best nutrition practices for your pets.",

                        ContactInfo = "777-888-9999"
                    },

                    new PetActivity {
                        ActivityNumber = 10,
                        ActivityName = "Dog Walking Group",
                        ActivityType = "Outdoor",
                        Location = "6th of October",
                        Description = "Join our group walk through the park for dogs and their owners.",

                        ContactInfo = "888-999-0000"
                    },

                    new PetActivity {
                        ActivityNumber = 11,
                        ActivityName = "Pet First Aid Training",
                        ActivityType = "Workshop",
                        Location = "Tagmoa",
                        Description = "Learn essential first aid skills for your pets in an emergency.",

                        ContactInfo = "999-000-1111"
                    },

                    new PetActivity {
                        ActivityNumber = 12,
                        ActivityName = "Feline Behavior Seminar",
                        ActivityType = "Seminar",
                        Location = "Nasr City",
                        Description = "A seminar on understanding and managing common feline behaviors.",

                        ContactInfo = "000-111-2222"
                    },

                    new PetActivity {
                        ActivityNumber = 13,
                        ActivityName = "Pet-Friendly Home Design",
                        ActivityType = "Workshop",
                        Location = "6th of October",
                        Description = "Learn how to design a pet-friendly home for your furry friends.",

                        ContactInfo = "111-222-3333"
                    },

                    new PetActivity {
                        ActivityNumber = 14,
                        ActivityName = "Senior Pet Care Talk",
                        ActivityType = "Seminar",
                        Location = "Tagmoa",
                        Description = "A talk about the special care needed for older pets.",

                        ContactInfo = "222-333-4444"
                    },

                    new PetActivity {
                        ActivityNumber = 15,
                        ActivityName = "Pet Massage Class",
                        ActivityType = "Workshop",
                        Location = "Nasr City",
                        Description = "Learn the basics of massaging your pet for relaxation and health.",

                        ContactInfo = "333-444-5555"
                    },
                 });
            modelBuilder.Entity<MarketPlaceEntity>()
                .HasData(new MarketPlaceEntity[] {
                    new MarketPlaceEntity{
                        Id = 1,
                        StoreName = "Pet World",
                        Location = "Nasr City",
                        ContactInfo = "111-222-3333",
                        Products = "Pet food, Pet toys, Pet accessories",
                        Description = "A pet store offering a variety of pet products and accessories.",
                        OpeningHours = "9:00 AM - 8:00 PM",
                        PaymentMethods = "Cash, Credit Card, PayPal"
                     },
                    new MarketPlaceEntity{
                             Id = 2,
                            StoreName = "Paws & Claws",
                            Location = "6th of October",
                            ContactInfo = "444-555-6666",
                            Products = "Dog collars, Cat trees, Pet grooming products",
                            Description = "Specialized store for pet grooming supplies and accessories.",
                            OpeningHours = "10:00 AM - 7:00 PM",
                            PaymentMethods = "Cash, Debit Card"
                     },
                    new MarketPlaceEntity{
                            Id = 3,
                            StoreName = "Furry Friends Boutique",
                            Location = "Tagmoa",
                            ContactInfo = "777-888-9999",
                            Products = "Pet apparel, Leashes, Pet beds",
                            Description = "A boutique for fashionable pet clothing and accessories.",
                            OpeningHours = "11:00 AM - 6:00 PM",
                            PaymentMethods = "Cash, Credit Card"
                     },
                    new MarketPlaceEntity{
                            Id = 4,
                            StoreName = "The Pet Shop",
                            Location = "Nasr City",
                            ContactInfo = "555-666-7777",
                            Products = "Aquariums, Fish food, Birds cages",
                            Description = "Store selling fish tanks, aquatic life supplies, and pet birds.",
                            OpeningHours = "8:00 AM - 8:00 PM",
                            PaymentMethods = "Cash, Credit Card"
                     },
                    new MarketPlaceEntity{
                            Id = 5,
                            StoreName = "Healthy Pets",
                            Location = "6th of October",
                            ContactInfo = "999-000-1111",
                            Products = "Pet food, Vitamins, Supplements",
                            Description = "Offering a wide range of healthy products for pets.",
                            OpeningHours = "9:00 AM - 5:00 PM",
                            PaymentMethods = "Cash, Debit Card, PayPal"
                     },
                    new MarketPlaceEntity{
                            Id = 6,
                            StoreName = "Pet Supplies Hub",
                            Location = "Tagmoa",
                            ContactInfo = "333-444-5555",
                            Products = "Pet cages, Pet carriers, Pet cleaning products",
                            Description = "A one-stop shop for all your pet supply needs.",
                            OpeningHours = "10:00 AM - 7:00 PM",
                            PaymentMethods = "Cash, Credit Card"
                     }
                });

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 1,
                    Name = "Rania Elmorshidy",
                    Phone = "01128394759",
                    Date = DateTime.Parse("2024-12-21").ToString("yyyy-MM-dd")
                },
                new Reservation
                {
                    Id = 2,
                    Name = "Nada Waleed",
                    Phone = "01234567893",
                    Date = DateTime.Parse("2024-12-22").ToString("yyyy-MM-dd")
                }
            );

            modelBuilder.Entity<BreedInfo>().HasData(
                new BreedInfo { Id = 1, PetType = "Dog", Breed = "Golden Retriever", Description = "Golden Retrievers are friendly, intelligent, and devoted.", ImageUrl = "golden_retriever.jpg" },
                new BreedInfo { Id = 2, PetType = "Dog", Breed = "Bulldog", Description = "Bulldogs are muscular, brave, and affectionate.", ImageUrl = "bulldog.jpg" },
                new BreedInfo { Id = 3, PetType = "Dog", Breed = "Labrador Retriever", Description = "Labrador Retrievers are outgoing, even-tempered, and gentle.", ImageUrl = "labrador_retriever.jpg" },
                new BreedInfo { Id = 4, PetType = "Cat", Breed = "Persian", Description = "Persians are calm, gentle, and make great lap cats.", ImageUrl = "persian.jpg" },
                new BreedInfo { Id = 5, PetType = "Cat", Breed = "Maine Coon", Description = "Maine Coons are known for their large size, friendly nature, and intelligence.", ImageUrl = "maine_coon.jpg" },
                new BreedInfo { Id = 6, PetType = "Cat", Breed = "Siamese", Description = "Siamese cats are social, vocal, and affectionate.", ImageUrl = "siamese.jpg" },
                new BreedInfo { Id = 7, PetType = "Bird", Breed = "Parrot", Description = "Parrots are intelligent, social, and colorful.", ImageUrl = "parrot.jpg" },
                new BreedInfo { Id = 8, PetType = "Bird", Breed = "Canary", Description = "Canaries are small, colorful, and great singers.", ImageUrl = "canary.jpg" },
                new BreedInfo { Id = 9, PetType = "Bird", Breed = "Finch", Description = "Finches are small, active birds with colorful feathers.", ImageUrl = "finch.jpg" }
            );
            base.OnModelCreating(modelBuilder);
            }
        }
    }
