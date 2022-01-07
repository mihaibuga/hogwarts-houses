using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL.Interfaces
{
    public interface IRoomService : IBaseService<Room>
    {
        Task<List<Room>> GetRoomsForRatOwners();
        Task<List<Room>> GetAvailableRooms();
    }
}
