using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using CoctailBot.Interfaces;
using CoctailBot.Resources;
using CoctailBot.Services;
using System;

namespace CoctailBot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class CategoryCocktailCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = CategoryCocktail.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IApiService workWithApi = new ApiService();
            var chatId = message.Chat.Id;
            var data = message.Text.Replace("/c", "");
            var formatTextTwoSpace = data.Replace("__","/");
            var coctails = workWithApi.GetCocktailsByCategoryAsync(formatTextTwoSpace.Replace("_or_", " / ")).GetAwaiter().GetResult();
            try
            {
                foreach (var coctail in coctails.drinks)
                {
                    await client.SendTextMessageAsync(chatId, $"\nCocktail ID: /id{coctail.idDrink}\U0001F379 \nCocktail name:{coctail.strDrink} \n{coctail.strDrinkThumb}");
                }
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
