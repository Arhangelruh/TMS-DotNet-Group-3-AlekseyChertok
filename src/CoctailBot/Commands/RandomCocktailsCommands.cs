using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;

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
            ApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var recponse = workWithApi.RandomCocktail("").GetAwaiter().GetResult();
            foreach (var item in recponse)
            {
                await client.SendTextMessageAsync(chatId, $"CocktailId: {item.idDrink} CoctailName: {item.strDrink} \nInstructions: \n{item.strInstructions} \n{item.strDrinkThumb}");
            }
              
                    }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
