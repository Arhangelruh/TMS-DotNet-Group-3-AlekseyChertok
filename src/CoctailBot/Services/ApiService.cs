using System.Collections.Generic;
using System.Threading.Tasks;
using CoctailBot.Helpers;
using CoctailBot.Interfaces;
using CoctailBot.Models;
using Flurl;
using Flurl.Http;
namespace CoctailBot.Services

{
    /// <inheritdoc cref="IApiService"/>
    public class ApiService : IApiService
    {
        
        public async Task <CocktailsIngredients> GetCocktailsByIngredientAsync(string ingredientsName)
        {
            return await Constants.searchByMulti
                .SetQueryParams(new { i = ingredientsName })
                .GetJsonAsync<CocktailsIngredients>();
        }

        public async Task<CocktailsRecipes> GetCocktailsByRecipeAsync(string CocktailName)
        {
            
            return await Constants.searchCocktailByname
                .SetQueryParams(new { s = CocktailName })
                .GetJsonAsync<CocktailsRecipes>();
        }

        public async Task <CocktailsRecipes> GetCocktailsByID(string recipeID)
        {
            return await Constants.lookupFullCocktaildetailsById
                .SetQueryParams(new { i = recipeID })
                .GetJsonAsync<CocktailsRecipes>();          
        }

        public async Task<IEnumerable<CocktailRecipe>> RandomCocktail(string RandomCocktail)
        {
            var response = await Constants.lookupaRandomCocktail
                 .GetJsonAsync<CocktailsRecipes>();
            var coctail = response.drinks;
            return coctail;
        }

        public async Task<IEnumerable<CocktailRecipe>> listCategoriesCocktail(string CategoriesCocktail)
        {
            var response = await Constants.listCategories
                .SetQueryParams(new { c = "list" })
                .GetJsonAsync<CocktailsRecipes>();
            var coctail = response.drinks;
            return coctail;
        }

        public async Task<IEnumerable<CocktailRecipe>> listIngredientsCocktail(string IngredientsCocktail)
        {
            var response = await Constants.listCategories
                .SetQueryParams(new { i = "list" })
                .GetJsonAsync<CocktailsRecipes>();
            var coctail = response.drinks;
            return coctail;
        }

        public async Task<IEnumerable<CocktailRecipe>> listAlcoholicCocktail(string AlcoholicCocktail)
        {
            var response = await Constants.listCategories
                .SetQueryParams(new { a = "list" })
                .GetJsonAsync<CocktailsRecipes>();
            var coctail = response.drinks;
            return coctail;
        }

        public async Task<CocktailsIngredients> GetCocktailsByTypeAsync(string type)
        {
            return await Constants.searchByMulti
                .SetQueryParams(new { a = type })
                .GetJsonAsync<CocktailsIngredients>();
        }

        public async Task<CocktailsIngredients> GetCocktailsByCategoryAsync(string category)
        {
            return await Constants.searchByMulti
                .SetQueryParams(new { c = category })
                .GetJsonAsync<CocktailsIngredients>();
        }
    }
}


