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
    public class RecipeRepository : IRecipeRepository
    {
        private readonly HogwartsContext _context;

        public RecipeRepository(HogwartsContext context)
        {
            _context = context;
        }

        public async Task Add(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Recipe> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Recipe>> GetAll()
        {
            return _context.Recipes
                .Include(recipe => recipe.Ingredients)
                .ToListAsync();
        }

        public Task Update(Recipe item)
        {
            throw new System.NotImplementedException();
        }
    }
}
