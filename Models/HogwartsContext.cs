using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Models
{
    public class HogwartsContext : DbContext
    {
        public const int MaxIngredientsForPotions = 5;

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

        public async void AddRoom(Room room)
        {
            await Rooms.AddAsync(room);
            this.SaveChanges();
        }

        public Task<Room> GetRoom(long roomId)
        {
            return Rooms
                .Where(room => room.ID == roomId)
                .Include(room => room.Residents)
                .FirstAsync();
        }

        public Task<List<Room>> GetAllRooms()
        {
            return Rooms.Include(room => room.Residents).ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            var roomInDB = await Rooms.FindAsync(room.ID);

            if (roomInDB != null)
            {
                roomInDB.Capacity = room.Capacity;

                await SaveChangesAsync();
            }
        }

        public async Task DeleteRoom(long id)
        {
            Room roomToDelete = await Rooms.FindAsync(id);

            if (roomToDelete != null)
            {
                Rooms.Remove(roomToDelete);
                await SaveChangesAsync();
            }
        }

        public Task<List<Room>> GetRoomsForRatOwners()
        {
            return Rooms
               .Where(room => room.Residents == null
                   || !room.Residents.Any(resident => 
                    (resident.PetType != PetType.Cat 
                    || resident.PetType != PetType.Owl)))
               .ToListAsync();
        }

        public Task<List<Room>> GetAvailableRooms()
        {
            return Rooms
                .Where(room => room.Residents.Count == 0)
                .ToListAsync();
        }
    }
}
