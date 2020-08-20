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
    public class IngredientsCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } =Ingredients.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var data = message.Text.Split(' ');
            var coctails = workWithApi.GetCocktailsByIngredientAsync(data[1]).GetAwaiter().GetResult();
            foreach (var coctail in coctails)
            {
                await client.SendTextMessageAsync(chatId, $"\nCocktail ID: {coctail.idDrink} \nCocktail name:{coctail.strDrink}");
                await client.SendTextMessageAsync(chatId, $"{coctail.strDrinkThumb}");
             }
        }
                /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
