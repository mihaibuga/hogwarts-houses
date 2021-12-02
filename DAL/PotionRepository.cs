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

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Add(Potion entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Potion Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Potion>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(long id)
        {
            throw new NotImplementedException();
        }
    }
}
