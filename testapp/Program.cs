using System;
using CoctailBot.Services;
using CoctailBot.Logics;
using CoctailBot.Interfaces;
using System.Linq;

namespace testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            IApiService workWithApi = new ApiService();
            GetCocktailsByIngridients getCocktailsByIngridients = new GetCocktailsByIngridients();
            GetIngridients getIngridients = new GetIngridients();
            var tmp = Console.ReadLine();
            var data =  tmp.Split(' ');
            var inputingridients = data[1].Split(',');
           
            var cocktails = workWithApi.GetCocktailsByIngredientAsync(inputingridients[0]).GetAwaiter().GetResult();

            Console.WriteLine(inputingridients.Length);
            if (inputingridients.Length == 1)

            {
                foreach (var coctail in cocktails.drinks)
                {
                    Console.WriteLine($"\nCocktail ID: /id{coctail.idDrink} \nCocktail name:{coctail.strDrink}");
                }
            }
            else
            {
                var coctailreciepes = getCocktailsByIngridients.GetCocktailRecipesAsync(cocktails).GetAwaiter().GetResult();
                int searshresult=0;
                int coctailsfound = 0;

                foreach (var coctail in coctailreciepes)
                {
                     searshresult = 1;
                    var ingridients = getIngridients.GetListIngridientsAsync(coctail).GetAwaiter().GetResult();
                    
                    for (var i = 1; i <= inputingridients.Length - 1; i++)
                    {
                        string ingridientName = inputingridients[i].ToLower();
                        
                        var ingridient = ingridients.FirstOrDefault(c => c.Contains(ingridientName));
                        if (ingridient != null)
                        {
                            searshresult += 1;
                        }
                    }

                    if (searshresult >= inputingridients.Length)
                    {
                        coctailsfound += 1;
                        Console.WriteLine($"\nCocktail ID: /id{coctail.idDrink} \nCocktail name:{coctail.strDrink}");
                    }
                }
                if (coctailsfound == 0)
                {
                    Console.WriteLine($"Cocktail name not found \U0001F631");
                    
                }
            }
        }
    }
}
