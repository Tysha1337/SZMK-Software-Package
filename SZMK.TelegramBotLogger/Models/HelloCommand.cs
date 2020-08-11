using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SZMK.TelegramBotLogger.Models
{
    public class HelloCommand : Command
    {
        public override string Name => "Привет";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            await client.SendTextMessageAsync(chatId, "Привет!");
        }
    }
}