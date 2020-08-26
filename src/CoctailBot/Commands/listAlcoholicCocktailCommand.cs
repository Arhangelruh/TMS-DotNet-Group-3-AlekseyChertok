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
            text.Append("\nCocktail types:");
            try
            {
                var coctails = workWithApi.listAlcoholicCocktail("").GetAwaiter().GetResult();
                foreach (var coctail in coctails)
                {
                    text.Append($"\n /t{coctail.strAlcoholic.Replace(" ", "_")}");
                }
                await client.SendTextMessageAsync(chatId, text.ToString());
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
