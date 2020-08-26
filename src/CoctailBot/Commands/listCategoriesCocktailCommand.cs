using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;
using System.Text;
using System;

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

            try
            {
                var coctails = workWithApi.listCategoriesCocktail("").GetAwaiter().GetResult();
                text.Append("\nCocktail categories:");

                foreach (var coctail in coctails)
                {
                    var formatTextSpaceSlashSpais = coctail.strCategory.Replace(" / ", "_or_");
                    var fomatTextOneSlash = formatTextSpaceSlashSpais.Replace("/", "__");
                    text.Append($"\n/c{fomatTextOneSlash.Replace(" ", "_")}");
                }
                await client.SendTextMessageAsync(chatId, text.ToString());
            }
            catch (NullReferenceException)
            {
                await client.SendTextMessageAsync(chatId, $"Error \U0001F631 please try again leater \U0001F64F");
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
