using HogwartsPotions.DAL.Interfaces;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Add(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Room Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetAll()
        {
            return _context.Rooms
                .Include(room => room.Residents)
                .ToListAsync();
        }

        public void Update(long id)
        {
            throw new NotImplementedException();
        }
    }
}
