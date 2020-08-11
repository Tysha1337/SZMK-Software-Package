using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;

namespace SZMK.TelegramBotLogger.Models
{
    public class Bot
    {
        public static TelegramBotClient client;

        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());

            var hook = string.Format(AppSettings.Url, "api/message/update");

            client = new TelegramBotClient(AppSettings.Key);

            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}