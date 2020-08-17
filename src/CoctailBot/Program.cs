using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CoctailBot.Services;

namespace CoctailBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApiService apiService = new ApiService();
            CreateHostBuilder(args).Build().Run();
           
            var data = apiService.GetCocktailsByIngredientAsync("Gin").GetAwaiter().GetResult(); ;
            foreach (var item in data)
            {
                Console.WriteLine(item.strDrink + " " + item.idDrink);

            }
            Console.ReadLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
