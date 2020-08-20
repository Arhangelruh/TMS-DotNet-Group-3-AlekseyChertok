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
            var data = text.Replace("/id","");
            Console.WriteLine(data);
            
                var recponse = workWithApi.GetCocktailsByID(data).GetAwaiter().GetResult();
            
                foreach (var item in recponse.drinks)
                {
                
                    Console.WriteLine(item.strDrink);
               
                   
                }
            
            

        }
    }
}
