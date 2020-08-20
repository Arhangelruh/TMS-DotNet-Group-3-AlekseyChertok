using System;
using CoctailBot.Services;
using CoctailBot.Logics;

namespace testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetIngridients getIngridients = new GetIngridients();
            ApiService workWithApi = new ApiService();
            var text = Console.ReadLine();
            var data = text.Split(' ');
            Console.WriteLine(data[1]);
            var recponse = workWithApi.GetCocktailsByID(data[1]).GetAwaiter().GetResult();
            foreach (var item in recponse)
            {
                Console.WriteLine(item.strDrink);
            }
            

        }
    }
}
