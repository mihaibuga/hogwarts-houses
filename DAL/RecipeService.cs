using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using HogwartsPotions.DAL.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace HogwartsPotions.DAL
{
    public class RecipeService : IRecipeService
    {
        public const int MaxIngredientsForPotions = 5;

        private readonly IRecipeRepository _recipeRepository;
        private readonly IPotionRepository _potionRepository;

        public RecipeService(IRecipeRepository recipeRepository, IPotionRepository potionRepository)
        {
            _recipeRepository = recipeRepository;
            _potionRepository = potionRepository;
        }

        public async Task Add(Recipe recipe)
        {
            await _recipeRepository.Add(recipe);
        }

        public async Task Delete(long id)
        {
            await _recipeRepository.Delete(id);
        }

        public Task<Recipe> Get(long id)
        {
            return _recipeRepository.Get(id);
        }

        public Task<List<Recipe>> GetAll()
        {
            return _recipeRepository.GetAll();
        }

        public async Task<List<Recipe>> GetPossibleRecipesForPotion(long potionId)
        {
            List<Recipe> recipesContainingPotionIngredients = new List<Recipe>();
            Potion potion = await _potionRepository.Get(potionId);

            if (potion.Ingredients.Count < MaxIngredientsForPotions)
            {
                List<Recipe> recipes = await _recipeRepository.GetAll();

                recipesContainingPotionIngredients =
                    recipes
                        .Where(recipe => recipe
                            .HasAllIngredients(
                                potion.Ingredients,
                                potion.Ingredients.Count
                            )
                        )
                        .ToList();
            }

            return recipesContainingPotionIngredients;
        }

        public async Task Update(Recipe recipe)
        {
            await _recipeRepository.Update(recipe);
        }
    }
}
