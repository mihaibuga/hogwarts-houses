using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HogwartsPotions.Models.Entities
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Name { get; set; }

        public long? StudentID { get; set; }

        public Student Student { get; set; }

        public HashSet<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();

        public Recipe() { }

        public Recipe(string studentName, Potion potion)
        {
            Name = studentName + "'s discovery";
            StudentID = potion.StudentID;
            Ingredients.UnionWith(potion.Ingredients);
        }

        public bool HasAllIngredients(HashSet<Ingredient> ingredients, int maxIngredientsForPotions)
        {
            int sameIngredientsCounter = 0;

            foreach (var ingredientInRecipe in Ingredients.ToList().OrderBy(ingredient => ingredient.Name))
            {
                foreach (var ingredientToCompare in ingredients)
                {
                    if (ingredientInRecipe.Name == ingredientToCompare.Name)
                    {
                        sameIngredientsCounter++;
                        break;
                    }
                }
            }

            return sameIngredientsCounter == maxIngredientsForPotions;
        }
    }
}
