using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL.Interfaces
{
    public interface IPotionService : IBaseService<Potion>
    {
        Task<List<Potion>> GetPotionsByStudent(long studentId);
        Task<Potion> AddPotion(Potion potion);
        Task AddBrewingPotion(Potion potion);
        Task<Potion> AttachIngredientToPotion(long potionId, Ingredient ingredient);
    }
}
