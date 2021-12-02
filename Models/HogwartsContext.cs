using HogwartsPotions.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Models
{
    public class HogwartsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Potion> Potions { get; set; }

        public HogwartsContext(DbContextOptions<HogwartsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Student firstStudent = new Student { ID = 1, Name = "Hermione Granger", HouseType = Enums.HouseType.Gryffindor, PetType = Enums.PetType.Cat };
            Student secondStudent = new Student { ID = 2, Name = "Draco Malfoy", HouseType = Enums.HouseType.Slytherin, PetType = Enums.PetType.Owl };

            Room firstRoom = new Room { ID = 1, Capacity = 2 };
            Room secondRoom = new Room { ID = 2, Capacity = 2 };

            firstStudent.RoomID = firstRoom.ID;
            secondStudent.RoomID = secondRoom.ID;

            modelBuilder.Entity<Student>().HasData(firstStudent, secondStudent);
            modelBuilder.Entity<Room>().HasData(firstRoom, secondRoom);
        }
    }
}
