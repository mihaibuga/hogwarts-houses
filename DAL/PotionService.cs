using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using HogwartsPotions.DAL.Interfaces;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL
{
    public class PotionService : IPotionService
    {
        private readonly IRoomRepository _roomRepository;

        public PotionService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task Add(Potion item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Potion> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Potion>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Potion item)
        {
            throw new System.NotImplementedException();
        }
    }
}
