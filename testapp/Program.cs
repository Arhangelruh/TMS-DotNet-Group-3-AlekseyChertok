using System;
using CoctailBot.Services;

namespace testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiService workWithApi = new ApiService();
            var recponse = workWithApi.RandomCocktail("").GetAwaiter().GetResult();
            foreach (var item in  recponse)
            {
                Console.WriteLine(item.idDrink + "" +
item.strDrink + "" +
item.strDrinkAlternate + "" +
item.strDrinkES + "" +
item.strDrinkDE + "" +
item.strDrinkFR + "" +
item.strTags + "" +
item.strVideo + "" +
item.strCategory + "" +
item.strIBA + "" +
item.strAlcoholic + "" +
item.strGlass + "" +
item.strInstructions + "" +
item.strInstructionsES + "" +
item.strInstructionsDE + "" +
item.strInstructionsFR + "" +
item.strDrinkThumb + "" +
item.strIngredient1 + "" +
item.strIngredient2 + "" +
item.strIngredient3 + "" +
item.strIngredient4 + "" +
item.strIngredient5 + "" +
item.strIngredient6 + "" +
item.strIngredient7 + "" +
item.strIngredient8 + "" +
item.strIngredient9 + "" +
item.strIngredient10 + "" +
item.strIngredient11 + "" +
item.strIngredient12 + "" +
item.strIngredient13 + "" +
item.strIngredient14 + "" +
item.strIngredient15 + "" +
item.strMeasure1 + "" +
item.strMeasure2 + "" +
item.strMeasure3 + "" +
item.strMeasure4 + "" +
item.strMeasure5 + "" +
item.strMeasure6 + "" +
item.strMeasure7 + "" +
item.strMeasure8 + "" +
item.strMeasure9 + "" +
item.strMeasure10 + "" +
item.strMeasure11 + "" +
item.strMeasure12 + "" +
item.strMeasure13 + "" +
item.strMeasure14 + "" +
item.strMeasure15 + "" +
item.strCreativeCommonsConfirmed + "" +
item.dateModified);
            }
        }
    }
}
