using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;
using CoctailBot.Logics;
using System;

namespace CoctailBot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class NameCommand : ITelegramCommand
    {
        /// <inheritdoc/>
           public string Name { get; } = NameCocktail.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var data = message.Text.Replace("/name", "");
            var coctails = workWithApi.GetCocktailsByID(data).GetAwaiter().GetResult();
            try
            {
                foreach (var coctail in coctails.drinks)
            {
                await client.SendTextMessageAsync(chatId, $"\nCocktail ID: /id{coctail.idDrink}\U0001F379 \nCocktail name:{coctail.strDrink}");
                await client.SendTextMessageAsync(chatId, $"{coctail.strDrinkThumb}");
             }
        }
        catch (NullReferenceException)
            {
                await client.SendTextMessageAsync(chatId, $"Cocktail name {data} not found \U0001F631" );
    }
}
/// <inheritdoc/>
public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}