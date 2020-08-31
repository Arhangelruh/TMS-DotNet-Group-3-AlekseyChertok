using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoctailBot.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CoctailBot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    class UnknownCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = string.Empty;
        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, "Sorry i dont know this command(( Open /about and you see active commands");
        }
        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}