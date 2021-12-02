using HogwartsPotions.DAL.Interfaces;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL
{
    public class PotionRepository : IPotionRepository
    {
        private readonly HogwartsContext _context;

        public PotionRepository(HogwartsContext context)
        {
            _context = context;
        }

        public Task Add(Potion item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Potion> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Potion>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Potion item)
        {
            throw new NotImplementedException();
        }
    }
}
