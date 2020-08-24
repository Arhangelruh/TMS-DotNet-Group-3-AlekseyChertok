using CoctailBot.Interfaces;
using CoctailBot.Models;
using CoctailBot.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoctailBot.Logics
{
    public class GetCocktailsByIngridients
    {
        public async Task<List<CocktailRecipe>> GetCocktailRecipesAsync(CocktailsIngredients cocktail)
        {
            IApiService workWithApi = new ApiService();
            List<CocktailRecipe> getcoctails = new List<CocktailRecipe>();
            await Task.Run(() =>
            {
                foreach (var cocktailid in cocktail.drinks)
                {
                    try
                    {
                        var cocktailRecipe = workWithApi.GetCocktailsByID(cocktailid.idDrink).GetAwaiter().GetResult();
                        foreach (var recipe in cocktailRecipe.drinks)
                        {
                            getcoctails.Add(recipe);
                        }
                    }
                    catch { }
                }
            });

            return getcoctails;
        }

    }
}