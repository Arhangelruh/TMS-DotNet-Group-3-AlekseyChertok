using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;

namespace CoctailBot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class AboutCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = About.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, $"\U0001F389 {About.Message} \U0001F449 \n{About.MessageCommandRandom} \U0001F379 \n{About.MessageCommandlistCategories} \U0001F379 \n{About.MessageCommandlistIngredients} \U0001F379 \n{About.MessageCommandlistAlcoholic} \U0001F379 \n{About.MessageCommandlistSearchByIngredients} \U0001F379 \n{About.MessageCommandSearchCocktalByName} \U0001F379");
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
