﻿using CoctailBot.Commands;
using CoctailBot.Interfaces;
using System.Collections.Generic;

namespace CoctailBot.Services
{
    /// <inheritdoc cref="ICommandService"/>
    public class CommandService : ICommandService
    {
        private readonly IEnumerable<ITelegramCommand> _commands;

        /// <summary>
        /// Base constructor.
        /// </summary>
        public CommandService()
        {
            _commands = new List<ITelegramCommand>
            {
                 new StartCommand(),
                 new AboutCommand(),
               // что то должно быть, наши команды
            };
        }

        /// <inheritdoc/>
        public IEnumerable<ITelegramCommand> Get() => _commands;
    }
}
