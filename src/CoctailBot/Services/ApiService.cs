﻿using System.Collections.Generic;
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
        /// <summary>
        /// Поиск по ингредиенту.
        /// </summary>
        /// <param name="IngredientsName">Наименование ингредиента.</param>
        /// <returns></returns>
        public async Task <CocktailsIngredients> GetCocktailsByIngredientAsync(string ingredientsName)
        {
            return await Constants.searchByIngredient
                .SetQueryParams(new { i = ingredientsName })
                .GetJsonAsync<CocktailsIngredients>();
        }

        /// <summary>
        /// Название коктейля.
        /// </summary>
        /// <param name="CocktailName">Название коктейля.</param>
        /// <returns></returns>
        public async Task<CocktailsRecipes> GetCocktailsByRecipeAsync(string CocktailName)
        {
            
            return await Constants.searchCocktailByname
                .SetQueryParams(new { i = CocktailName })
                .GetJsonAsync<CocktailsRecipes>();
        }

        /// <summary>
        /// ID коктейля.
        /// </summary>
        /// <param name="recipeID">ID коктейля.</param>
        /// <returns></returns>
        public async Task <CocktailsRecipes> GetCocktailsByID(string recipeID)
        {
            return await Constants.lookupFullCocktaildetailsById
                .SetQueryParams(new { i = recipeID })
                .GetJsonAsync<CocktailsRecipes>();          
        }

        /// <summary>
        /// Случайный коктейль.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CocktailRecipe>> RandomCocktail(string RandomCocktail)
        {
            var response = await Constants.lookupaRandomCocktail
                 .GetJsonAsync<CocktailsRecipes>();
            var coctail = response.drinks;
            return coctail;
        }
        /// <summary>
        /// Категории коктейлей.
        /// </summary>
        /// <param name="CategoriesCocktail">Категории коктейлей.</param>
        /// <returns></returns>
        public async Task<IEnumerable<CocktailRecipe>> listCategoriesCocktail(string CategoriesCocktail)
        {
            var response = await Constants.listCategories
                .SetQueryParams(new { c = "list" })
                .GetJsonAsync<CocktailsRecipes>();
            var coctail = response.drinks;
            return coctail;
        }
        /// <summary>
        /// Ингредиенты коктейлей.
        /// </summary>
        /// <param name="IngredientsCocktail">Ингредиенты коктейлей.</param>
        /// <returns></returns>
        public async Task<IEnumerable<CocktailRecipe>> listIngredientsCocktail(string IngredientsCocktail)
        {
            var response = await Constants.listCategories
                .SetQueryParams(new { i = "list" })
                .GetJsonAsync<CocktailsRecipes>();
            var coctail = response.drinks;
            return coctail;
        }
        /// <summary>
        /// Вид коктейля.
        /// </summary>
        /// <param name="AlcoholicCocktail">Вид коктейля.</param>
        /// <returns></returns>
        public async Task<IEnumerable<CocktailRecipe>> listAlcoholicCocktail(string AlcoholicCocktail)
        {
            var response = await Constants.listCategories
                .SetQueryParams(new { a = "list" })
                .GetJsonAsync<CocktailsRecipes>();
            var coctail = response.drinks;
            return coctail;
        }
        
    }
}


