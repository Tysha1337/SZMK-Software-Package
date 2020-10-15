using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.BotLogger.Services.Settings;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace SZMK.BotLogger.Services.LogsSending
{
    public class BotTelegram
    {
        private TelegramBotClient Bot;

        Dictionary<long, string> users = new Dictionary<long, string>();

        public void StartAsync()
        {
            XDocument settings = XDocument.Load(PathProgram.TelegramBot);

            string Token = settings.Element("Settings").Element("Token").Value;

            string Host = settings.Element("Settings").Element("Host").Value;
            string Port = settings.Element("Settings").Element("Port").Value;

            if (String.IsNullOrEmpty(Host) && String.IsNullOrEmpty(Port))
            {
                Bot = new TelegramBotClient(Token);
            }
            else
            {
                var Proxy = new WebProxy(Host, Convert.ToInt32(Port)) { UseDefaultCredentials = true };
                Bot = new TelegramBotClient(Token, webProxy: Proxy);
            }

            Bot.SetWebhookAsync("");

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnInlineQuery += BotOnInlineQueryReceived;
            Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            Bot.OnReceiveError += BotOnReceiveError;

            Bot.StartReceiving(Array.Empty<UpdateType>());
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text)
                return;

            switch (message.Text)
            {
                case "/start":
                    await SendChooseProduct();
                    break;
                case "За сутки":
                    await SendDocument();
                    break;
                case "За неделю":
                    await SendDocument();
                    break;
                case "За месяц":
                    await SendDocument();
                    break;
                default:
                    await CheckedProduct();
                    break;
            }

            async Task SendChooseProduct()
            {
                XDocument products = XDocument.Load(PathProgram.Products);

                String[] products_mas = products.Element("Products").Elements("Product").Select(p => p.Value).ToArray();

                var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                    GetKeyboardButtons(products_mas),
                    resizeKeyboard: true
                    );

                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Выберите продукт!",
                    replyMarkup: replyKeyboardMarkup

                );
            }

            async Task CheckedProduct()
            {
                XDocument products = XDocument.Load(PathProgram.Products);

                String[] products_mas = products.Element("Products").Elements("Product").Select(p => p.Value).ToArray();

                if (products_mas.Where(p => p == message.Text).Count() == 0)
                {
                    var replyKeyboardMarkup = new ReplyKeyboardMarkup(GetKeyboardButtons(products_mas), resizeKeyboard: true);

                    await Bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Продукт не найден, выберете его из списка!",
                        replyMarkup: replyKeyboardMarkup

                    );
                }
                else
                {
                    await SendPeriods();
                }
            }

            async Task SendPeriods()
            {
                var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                    new KeyboardButton[][]
                    {
                        new KeyboardButton[] { "За сутки"},
                        new KeyboardButton[] { "За неделю"},
                        new KeyboardButton[] { "За месяц"},
                    },
                    resizeKeyboard: true
                    );

                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Выберите период!",
                    replyMarkup: replyKeyboardMarkup

                );
            }

            async Task SendDocument()
            {
                XDocument products = XDocument.Load(PathProgram.Products);

                String[] products_mas = products.Element("Products").Elements("Product").Select(p => p.Value).ToArray();

                if (users.ContainsKey(message.Chat.Id) && products_mas.Where(p => p == users[message.Chat.Id]).Count() != 0)
                {
                    if (message.Text == "За сутки")
                    {

                    }
                    else if (message.Text == "За неделю")
                    {

                    }
                    else
                    {

                    }

                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadDocument);

                    const string filePath = @"Files/tux.jpg";
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
                    await Bot.SendPhotoAsync(
                        chatId: message.Chat.Id,
                        photo: new InputOnlineFile(fileStream, fileName),
                        caption: "Nice Picture"
                    );
                }
                else
                {
                    var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                    GetKeyboardButtons(products_mas),
                    resizeKeyboard: true
                    );

                    await Bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Вы не выбрали продукт, выберите его из списка!",
                        replyMarkup: replyKeyboardMarkup

                    );
                }
            }

            if (!users.ContainsKey(messageEventArgs.Message.Chat.Id))
            {
                users.Add(messageEventArgs.Message.Chat.Id, messageEventArgs.Message.Text);
            }
            else
            {
                users[messageEventArgs.Message.Chat.Id] = messageEventArgs.Message.Text;
            }
        }
        public static KeyboardButton[][] GetKeyboardButtons(string[] products)
        {
            var kb = new KeyboardButton[products.Length][];

            for (int i = 0; i < products.Length; i++)
            {
                kb[i] = new KeyboardButton[] { products[i] };
            }

            return kb;
        }
        async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            await Bot.AnswerCallbackQueryAsync(
                callbackQueryId: callbackQuery.Id,
                text: $"Received {callbackQuery.Data}"
            );

            await Bot.SendTextMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                text: $"Received {callbackQuery.Data}"
            );
        }

        #region Inline Mode

        async void BotOnInlineQueryReceived(object sender, InlineQueryEventArgs inlineQueryEventArgs)
        {
            Console.WriteLine($"Received inline query from: {inlineQueryEventArgs.InlineQuery.From.Id}");

            InlineQueryResultBase[] results = {
                // displayed result
                new InlineQueryResultArticle(
                    id: "3",
                    title: "TgBots",
                    inputMessageContent: new InputTextMessageContent(
                        "hello"
                    )
                )
            };
            await Bot.AnswerInlineQueryAsync(
                inlineQueryId: inlineQueryEventArgs.InlineQuery.Id,
                results: results,
                isPersonal: true,
                cacheTime: 0
            );
        }

        void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
        {
            Console.WriteLine($"Received inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
        }

        #endregion

        void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message
            );
        }
    }
}
