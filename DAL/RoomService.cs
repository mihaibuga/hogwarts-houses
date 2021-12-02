using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using HogwartsPotions.DAL.Interfaces;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Add()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Room entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Room Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Room>> GetAll()
        {
            return await _roomRepository.GetAll();
        }

        public void Update(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
