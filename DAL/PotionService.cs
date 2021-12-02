using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using HogwartsPotions.DAL.Interfaces;
using System.Threading.Tasks;
using HogwartsPotions.Models.Enums;

namespace HogwartsPotions.DAL
{
    public class PotionService : IPotionService
    {
        public const int MaxIngredientsForPotions = 5;

        private readonly IPotionRepository _potionRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IStudentRepository _studentRepository;

        public PotionService(IPotionRepository potionRepository, 
            IRecipeRepository recipeRepository,
            IStudentRepository studentRepository)
        {
            _potionRepository = potionRepository;
            _recipeRepository = recipeRepository;
            _studentRepository = studentRepository;
        }

        public async Task Add(Potion item)
        {
            await _potionRepository.Add(item);
        }

        public async Task AddBrewingPotion(Potion potion)
        {
            await _potionRepository.AddBrewingPotion(potion);
        }

        public async Task<Potion> AddPotion(Potion potion)
        {
            Student studentInDB = await _studentRepository.Get((long)potion.StudentID);

            List<Recipe> recipes = await _recipeRepository.GetAll();

            potion.CheckBrewingStatus(recipes, MaxIngredientsForPotions);

            if (potion.BrewingStatus == BrewingStatus.Discovery)
            {
                Recipe dicoveredRecipe = new Recipe(studentInDB.Name, potion);

                await _recipeRepository.Add(dicoveredRecipe);

                long dicoveredRecipeId = dicoveredRecipe.ID;

                potion.RecipeID = dicoveredRecipeId;
            }

            return await _potionRepository.AddPotion(potion);
        }

        public async Task<Potion> AttachIngredientToPotion(long potionId, Ingredient ingredient)
        {
            Potion potion = await Get(potionId);

            List<Recipe> recipes = await _recipeRepository.GetAll();

            if (potion.Ingredients.Count < MaxIngredientsForPotions)
            {
                potion = await _potionRepository
                    .AttachIngredientToPotion(potion, ingredient, recipes, MaxIngredientsForPotions);
            }

            return potion;
        }

        public async Task Delete(long id)
        {
            await _potionRepository.Delete(id);
        }

        public Task<Potion> Get(long id)
        {
            return _potionRepository.Get(id);
        }

        public Task<List<Potion>> GetAll()
        {
            return _potionRepository.GetAll();
        }

        public Task<List<Potion>> GetPotionsByStudent(long studentId)
        {
            return _potionRepository.GetPotionsByStudent(studentId);
        }

        public Task Update(Potion item)
        {
            throw new System.NotImplementedException();
        }
    }
}
