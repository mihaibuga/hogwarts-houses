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
            return Rooms.ToListAsync();
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
