using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Models
{
    public class HogwartsContext : DbContext
    {
        public const int MaxIngredientsForPotions = 5;

        public DbSet<Student> Students { get; set; }

        public DbSet<Room> Rooms { get; set; }

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
            throw new NotImplementedException();
        }

        public Task<Room> GetRoom(long roomId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetAllRooms()
        {
            return Rooms.Include(room => room.Residents).ToListAsync();
        }

        public async void UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public async void DeleteRoom(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetRoomsForRatOwners()
        {
            throw new NotImplementedException();
        }
    }
}
