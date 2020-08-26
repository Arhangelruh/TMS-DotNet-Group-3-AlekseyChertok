using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;
using CoctailBot.Logics;
using System.Linq;
using System;
using System.Net.Http;

namespace CoctailBot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class IngredientsCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = Ingredients.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IApiService workWithApi = new ApiService();
            GetCocktailsByIngridients getCocktailsByIngridients = new GetCocktailsByIngridients();
            GetIngridients getIngridients = new GetIngridients();
            var chatId = message.Chat.Id;
            var formattext = message.Text.Replace(", ", ",");
            var data = formattext.Split(' ');

            try
            {
                var inputingridients = data[1].Split(',');
                var cocktails = workWithApi.GetCocktailsByIngredientAsync(inputingridients[0]).GetAwaiter().GetResult();
                if (inputingridients.Length == 1)
                {
                    foreach (var coctail in cocktails.drinks)
                    {
                        await client.SendTextMessageAsync(chatId, $"\nCocktail ID: /id{coctail.idDrink} \nCocktail name:{coctail.strDrink} \n{coctail.strDrinkThumb}");
                    }
                }
                else
                {
                    var coctailreciepes = getCocktailsByIngridients.GetCocktailRecipesAsync(cocktails).GetAwaiter().GetResult();
                    int searshresult = 0;
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
                            await client.SendTextMessageAsync(chatId, $"\nCocktail ID: /id{coctail.idDrink} \nCocktail name:{coctail.strDrink} \n{coctail.strDrinkThumb}");
                        }
                    }
                    if (coctailsfound == 0)
                    {
                        await client.SendTextMessageAsync(chatId, $"Cocktail not found \U0001F631");

                    }
                }
            }
            catch (NullReferenceException)
            {
                await client.SendTextMessageAsync(chatId, $"Cocktail not found \U0001F631");
            }
            catch (IndexOutOfRangeException)
            {
                await client.SendTextMessageAsync(chatId, $"Cocktail not found \U0001F631");
            }
            catch (HttpRequestException)
            {
                await client.SendTextMessageAsync(chatId, $"Error request \U0001F631, try again");
            }
            catch (Exception)
            {
                await client.SendTextMessageAsync(chatId, $"Unknown command");
            }
        }
        /// <inheritdoc/>
        public bool Contains(Message message)
        {
            if (message != null)
            {
                return message.Type == MessageType.Text && message.Text.Contains(Name);
            }
            else
            {
                return false;
            }
        }
        // public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
