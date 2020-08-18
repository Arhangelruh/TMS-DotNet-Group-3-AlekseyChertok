using CoctailBot.Interfaces;
using CoctailBot.Resources;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace CoctailBot.Commands
{
    public class StartCommand : ITelegramCommand
    {
        /// <inheritdoc cref="ITelegramCommand"/>
        /// <inheritdoc/>
        public string Name { get; } = Start.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, $"{Start.Message} \U0001F369");
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}

