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

        public void Add()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Potion entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Potion Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Potion>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
