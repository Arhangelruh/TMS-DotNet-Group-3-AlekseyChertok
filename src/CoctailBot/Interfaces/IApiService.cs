using CoctailBot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoctailBot.Interfaces
{
    /// <summary>
    /// Api requests service
    /// </summary>
    interface IApiService
    {
        /// <summary>
        /// Request coctails by base ingridient
        /// </summary>
        /// <param name="ingredientsName"></param>
        /// <returns>List coctails</returns>
        Task<IEnumerable<CocktailIngredient>> GetCocktailsByIngredientAsync(string ingredientsName);

        /// <summary>
        /// Request coctails by name
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns>List coctails</returns>
        Task<IEnumerable<CocktailRecipe>> GetCocktailsByRecipeAsync(string recipeName);

        /// <summary>
        /// Request coctail by ID
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns>Coctail recipe</returns>
        Task<IEnumerable<CocktailRecipe>> GetCocktailsByID(string recipeID);

        /// <summary>
        /// Request random coctail
        /// </summary>
        /// <param name="RandomCocktail"></param>
        /// <returns>Coctail recipe</returns>
        Task<IEnumerable<CocktailRecipe>> RandomCocktail(string RandomCocktail);

        /// <summary>
        /// Request list categories
        /// </summary>
        /// <param name="CategoriesCocktail"></param>
        /// <returns>All catigories</returns>
        Task<IEnumerable<CocktailRecipe>> listCategoriesCocktail(string CategoriesCocktail);

        /// <summary>
        /// Request list ingridients
        /// </summary>
        /// <param name="IngredientsCocktail"></param>
        /// <returns>All ingridients</returns>
        Task<IEnumerable<CocktailRecipe>> listIngredientsCocktail(string IngredientsCocktail);

        /// <summary>
        /// Recuest coctail by type in alcohol
        /// </summary>
        /// <param name="AlcoholicCocktail"></param>
        /// <returns>List coctails by type</returns>
        Task<IEnumerable<CocktailRecipe>> listAlcoholicCocktail(string AlcoholicCocktail);
    }
}
