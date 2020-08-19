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
    public class listIngredientsCocktailCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = listIngredients.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var coctails = workWithApi.listIngredientsCocktail("").GetAwaiter().GetResult();

            foreach (var coctail in coctails)

                await client.SendTextMessageAsync(chatId, $"\nThe main ingredient in cocktails: \n{coctail.strIngredient1}");

        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
