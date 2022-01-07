using HogwartsPotions.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogwartsPotions.Models.Entities
{
    public class Potion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Name { get; set; }

        public BrewingStatus BrewingStatus { get; set; }

        public long? StudentID { get; set; }

        public long? RecipeID { get; set; }

        public Student Student { get; set; }

        public Recipe Recipe { get; set; }

        public HashSet<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();

        public void CheckBrewingStatus(List<Recipe> allRecipes, int maxIngredientsForPotions)
        {
            if (Ingredients.Count < maxIngredientsForPotions)
            {
                BrewingStatus = BrewingStatus.Brew;
            }
            else if (CheckIfRecipeAlreadyExists(allRecipes, maxIngredientsForPotions))
            {
                BrewingStatus = BrewingStatus.Replica;
            }
            else
            {
                BrewingStatus = BrewingStatus.Discovery;
            }
        }

        private bool CheckIfRecipeAlreadyExists(
            List<Recipe> allRecipes, int maxIngredientsForPotions)
        {
            foreach (Recipe recipe in allRecipes)
                if (recipe
                    .HasAllIngredients(Ingredients, maxIngredientsForPotions))
                {
                    return true;
                }
            return false;
        }
    }
}
