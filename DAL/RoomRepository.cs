using HogwartsPotions.DAL.Interfaces;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HogwartsContext _context;

        public RoomRepository(HogwartsContext context)
        {
            _context = context;
        }

        public async Task Add(Room room)
        {
            await _context.Rooms.AddAsync(room);
            _context.SaveChanges();
        }

        public async Task Delete(long id)
        {
            Room roomToDelete = await _context.Rooms.FindAsync(id);

            if (roomToDelete != null)
            {
                _context.Rooms.Remove(roomToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Room> Get(long roomId)
        {
            return _context.Rooms
                .Where(room => room.ID == roomId)
                .Include(room => room.Residents)
                .FirstAsync();
        }

        public Task<List<Room>> GetAll()
        {
            return _context.Rooms
                .Include(room => room.Residents)
                .ToListAsync();
        }

        public Task<List<Room>> GetAvailableRooms()
        {
            return _context.Rooms
                .Where(room => room.Residents.Count == 0)
                .ToListAsync();
        }

        public Task<List<Room>> GetRoomsForRatOwners()
        {
            return _context.Rooms
               .Where(room => room.Residents == null
                   || !room.Residents.Any(resident =>
                    (resident.PetType != PetType.Cat
                    || resident.PetType != PetType.Owl)))
               .ToListAsync();
        }

        public async Task Update(Room room)
        {
            var roomInDB = await _context.Rooms.FindAsync(room.ID);

            if (roomInDB != null)
            {
                roomInDB.Capacity = room.Capacity;

                await _context.SaveChangesAsync();
            }
        }
    }
}
