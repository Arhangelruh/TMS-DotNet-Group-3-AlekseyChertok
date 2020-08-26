using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;
using System.Text;

namespace CoctailBot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class listAlcoholicCocktailCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = listAlcoholic.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            StringBuilder text = new StringBuilder();
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var coctails = workWithApi.listAlcoholicCocktail("").GetAwaiter().GetResult();
            text.Append("\nCocktail types:");
            foreach (var coctail in coctails)
            {
                text.Append($"\n /t{coctail.strAlcoholic}");
            }
            await client.SendTextMessageAsync(chatId,text.ToString());
        }

        /// <inheritdoc/>
        // public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
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
