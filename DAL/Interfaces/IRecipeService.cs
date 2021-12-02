using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL.Interfaces
{
    public interface IRecipeService : IBaseService<Recipe>
    {
        Task<List<Recipe>> GetPossibleRecipesForPotion(long potionId);
    }
}
