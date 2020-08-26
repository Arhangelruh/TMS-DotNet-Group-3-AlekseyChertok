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
    public class RandomCocktailsCommands : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = RandomCocktail.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            try
            {
                var coctails = workWithApi.RandomCocktail("").GetAwaiter().GetResult();
                foreach (var coctail in coctails)
                {
                    GetIngridients getIngridients = new GetIngridients();
                    string coctailIngridient = "";
                    var ingridients = getIngridients.GetListIngridientsAsync(coctail).GetAwaiter().GetResult();
                    foreach (var ingridient in ingridients)
                    {
                        coctailIngridient += ingridient + "; ";
                    }

                    await client.SendTextMessageAsync(chatId, $"Coctail Name: {coctail.strDrink} \nCoctail ingridients: \n{coctailIngridient} \nInstructions: \n{coctail.strInstructions} \n{coctail.strDrinkThumb}");
                }
            }
            catch (NullReferenceException)
            {
                await client.SendTextMessageAsync(chatId, $"Cocktail not found \U0001F630");
            }
            catch (Exception)
            {
                await client.SendTextMessageAsync(chatId, $"Error \U0001F631 please try again leater \U0001F64F");
            };
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
    }
}
