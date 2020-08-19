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
            var recponse = workWithApi.RandomCocktail("").GetAwaiter().GetResult();
            foreach (var item in recponse)
            {
                var ingridients = getIngridients.GetListIngridients(item);
                foreach (var ingridient in ingridients) {
                    Console.WriteLine(ingridient);
                }
            }
            

        }
    }
}
