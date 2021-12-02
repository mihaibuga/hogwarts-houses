using HogwartsPotions.DAL.Interfaces;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddBrewingPotion(Potion potion)
        {
            potion.BrewingStatus = BrewingStatus.Brew;

            await _context.Potions.AddAsync(potion);
            await _context.SaveChangesAsync();
        }

        public async Task<Potion> AddPotion(Potion potion)
        {
            await _context.Potions.AddAsync(potion);
            await _context.SaveChangesAsync();

            return potion;
        }

        public async Task<Potion> AttachIngredientToPotion(Potion potion, Ingredient ingredient,
            List<Recipe> recipes, int maxIngredientsForPotions)
        {
            potion.Ingredients.Add(ingredient);

            if (potion.Ingredients.Count == maxIngredientsForPotions)
            {
                potion.CheckBrewingStatus(recipes, maxIngredientsForPotions);
            }

            await _context.SaveChangesAsync();

            return potion;
        }

        public async Task Delete(long id)
        {
            Potion potionToDelete = await _context.Potions
                .Where(potion => potion.ID == id)
                .Include(potion => potion.Ingredients)
                .SingleOrDefaultAsync();

            if (potionToDelete != null)
            {
                _context.Potions.Remove(potionToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Potion> Get(long potionId)
        {
            return _context.Potions
                .Where(potion => potion.ID == potionId)
                .Include(potion => potion.Student)
                .Include(potion => potion.Recipe)
                .Include(potion => potion.Ingredients)
                .FirstAsync();
        }

        public Task<List<Potion>> GetAll()
        {
            return _context.Potions
                .Include(potion => potion.Student)
                .Include(potion => potion.Recipe)
                .Include(potion => potion.Ingredients)
                .ToListAsync();
        }

        public Task<List<Potion>> GetPotionsByStudent(long studentId)
        {
            return _context.Potions
                .Where(potion => potion.StudentID == studentId)
                .Include(potion => potion.Student)
                .Include(potion => potion.Recipe)
                .Include(potion => potion.Ingredients)
                .ToListAsync();
        }

        public Task Update(Potion item)
        {
            throw new NotImplementedException();
        }
    }
}
