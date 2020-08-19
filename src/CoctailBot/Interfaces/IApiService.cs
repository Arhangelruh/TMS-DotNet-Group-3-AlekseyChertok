using CoctailBot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoctailBot.Interfaces
{
    interface IApiService
    {
        Task<IEnumerable<CocktailIngredient>> GetCocktailsByIngredientAsync(string ingredientsName);
        Task<IEnumerable<CocktailRecipe>> GetCocktailsByRecipeAsync(string recipeName);
        Task<IEnumerable<CocktailRecipe>> GetCocktailsByID(string recipeID);
        Task<IEnumerable<CocktailRecipe>> RandomCocktail(string RandomCocktail);
        Task<IEnumerable<CocktailRecipe>> listCategoriesCocktail(string CategoriesCocktail);
        Task<IEnumerable<CocktailRecipe>> listIngredientsCocktail(string IngredientsCocktail);
        Task<IEnumerable<CocktailRecipe>> listAlcoholicCocktail(string AlcoholicCocktail);

    }
}
