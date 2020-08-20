using System;
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

            switch (message.Text.Split(' ').First())
            {
                // send custom keyboard
                case "/start":
                    await SendChooseProduct();
                    break;
                //case "Выбрать продукт":
                //    await SendProduct(message);
                //    break;
                //case "За день":
                //    await SendChooseProduct(message);
                //    break;
                //case "Неделя":
                //    await SendChooseProduct(message);
                //    break;
                //case "Месяц":
                //    await SendChooseProduct(message);
                //    break;
                //default:
                //    await CheckedProduct(message);
                //    break;
            }
            async Task SendChooseProduct()
            {
                var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                    new KeyboardButton[][]
                    {
                        new KeyboardButton[] { "Выбрать продукт"},
                    },
                    resizeKeyboard: true
                );

                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Choose",
                    replyMarkup: replyKeyboardMarkup

                );
            }
            //async Task SendChooseProduct()
            //{
            //    var replyKeyboardMarkup = new ReplyKeyboardMarkup(
            //        new KeyboardButton[][]
            //        {
            //            new KeyboardButton[] { "Выбрать продукт"},
            //        },
            //        resizeKeyboard: true
            //    );

            //    await Bot.SendTextMessageAsync(
            //        chatId: message.Chat.Id,
            //        text: "Choose",
            //        replyMarkup: replyKeyboardMarkup

            //    );
            //}
            async Task CheckedProduct()
            {
                XDocument products = XDocument.Load(PathProgram.Products);


                //if (BeforeMessage == "Выбрать продукт" && message ==)
                //        var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                //            new KeyboardButton[][]
                //            {
                //            new KeyboardButton[] { "Выбрать продукт"},
                //            },
                //            resizeKeyboard: true
                //        );

                //    await Bot.SendTextMessageAsync(
                //        chatId: message.Chat.Id,
                //        text: "Choose",
                //        replyMarkup: replyKeyboardMarkup

                //    );
                //}
                async Task SendDocument()
                {
                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                    const string filePath = @"Files/tux.png";
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
                    await Bot.SendPhotoAsync(
                        chatId: message.Chat.Id,
                        photo: new InputOnlineFile(fileStream, fileName),
                        caption: "Nice Picture"
                    );
                }

                async Task Usage()
                {
                    const string usage = "Usage:\n" +
                                            "/inline   - send inline keyboard\n" +
                                            "/keyboard - send custom keyboard\n" +
                                            "/photo    - send a photo\n" +
                                            "/request  - request location or contact";
                    await Bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: usage,
                        replyMarkup: new ReplyKeyboardRemove()
                    );
                }

                //BeforeMessage = message;
            }
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
