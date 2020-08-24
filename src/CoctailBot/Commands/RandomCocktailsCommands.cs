using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;
using CoctailBot.Logics;

namespace CoctailBot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class RandomCocktailsCommands : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = Random.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var coctails = workWithApi.RandomCocktail("").GetAwaiter().GetResult();
            foreach (var coctail in coctails)
            {
                //await client.SendTextMessageAsync(chatId, $"Coctail Name: {coctail.strDrink}");

                GetIngridients getIngridients = new GetIngridients();
                string coctailIngridient = "";
                var ingridients = getIngridients.GetListIngridientsAsync(coctail).GetAwaiter().GetResult();                
                foreach (var ingridient in ingridients)
                {
                    coctailIngridient += ingridient + "; ";
                }

                await client.SendTextMessageAsync(chatId, $"Coctail Name: {coctail.strDrink} \nCoctail ingridients: \n{coctailIngridient} \nInstructions: \n{coctail.strInstructions} \n{coctail.strDrinkThumb}");
                //await client.SendTextMessageAsync(chatId, $"\nInstructions: \n{coctail.strInstructions} \n{coctail.strDrinkThumb}");
            }
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
