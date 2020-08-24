using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;
using CoctailBot.Logics;
using System;

namespace CoctailBot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class IDCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = IDCocktails.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var data = message.Text.Replace("/id","");            
            var coctails = workWithApi.GetCocktailsByID(data).GetAwaiter().GetResult();
            try
            {
                foreach (var coctail in coctails.drinks)
                {
                   // await client.SendTextMessageAsync(chatId, $"Cocktail ID: {coctail.idDrink}");
                    
                   // await client.SendTextMessageAsync(chatId, $"Coctail Name: {coctail.strDrink}");
                    GetIngridients getIngridients = new GetIngridients();
                    string coctailIngridient = "";
                    var ingridients = getIngridients.GetListIngridientsAsync(coctail).GetAwaiter().GetResult();
                    foreach (var ingridient in ingridients)
                    {
                        coctailIngridient += ingridient + "; ";
                    }

                    await client.SendTextMessageAsync(chatId, $"Cocktail ID: { coctail.idDrink} \nCoctail Name: {coctail.strDrink} \nCoctail ingridients:{coctailIngridient} \nInstructions: \n{coctail.strInstructions} \n{coctail.strDrinkThumb}");

                    //await client.SendTextMessageAsync(chatId, $"\nInstructions: \n{coctail.strInstructions} \n{coctail.strDrinkThumb}");
                }
            }
            catch (NullReferenceException)
            {
                await client.SendTextMessageAsync(chatId, $"Cocktail id {data} not found \U0001F61E" );
            }
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
