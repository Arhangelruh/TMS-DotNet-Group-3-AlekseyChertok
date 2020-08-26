using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;
using System.Text;
using System.Net.Http;

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
            StringBuilder text = new StringBuilder();
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            try
            {
                var coctails = workWithApi.listIngredientsCocktail("").GetAwaiter().GetResult();
                text.Append($"\nThe main ingredient in cocktails:");
                foreach (var coctail in coctails)
                {
                    text.Append($"\n{coctail.strIngredient1}");
                }
                await client.SendTextMessageAsync(chatId, text.ToString());
            }
            catch (HttpRequestException)
            {
                await client.SendTextMessageAsync(chatId, $"Error request \U0001F631, try again");
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
    }
}
