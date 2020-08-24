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
    public class listCategoriesCocktailCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = listCategories.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            StringBuilder text = new StringBuilder();
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var coctails = workWithApi.listCategoriesCocktail("").GetAwaiter().GetResult();
            text.Append("\nCocktail categories:");            
            foreach (var coctail in coctails)
            {
                text.Append($"\n{coctail.strCategory}");               
            }
            await client.SendTextMessageAsync(chatId, text.ToString());
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
