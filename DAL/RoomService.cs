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

        public async Task Add(Room room)
        {
            await _roomRepository.Add(room);
        }

        public async Task Delete(long id)
        {
            await _roomRepository.Delete(id);
        }

        public Task<Room> Get(long id)
        {
            return _roomRepository.Get(id);
        }

        public Task<List<Room>> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Task<List<Room>> GetAvailableRooms()
        {
            return _roomRepository.GetAvailableRooms();
        }

        public Task<List<Room>> GetRoomsForRatOwners()
        {
            return _roomRepository.GetRoomsForRatOwners();
        }

        public async Task Update(Room room)
        {
            await _roomRepository.Update(room);
        }
    }
}
