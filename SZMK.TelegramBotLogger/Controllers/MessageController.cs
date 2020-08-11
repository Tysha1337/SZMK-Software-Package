using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using SZMK.TelegramBotLogger.Models;
using Telegram.Bot.Types;

namespace SZMK.TelegramBotLogger.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")]
        public async Task<IHttpActionResult> Update([FromBody]Update update)
        {
            var message = update.Message;

            var client = await Bot.Get();

            await client.SendTextMessageAsync(message.Chat.Id, "Тест");

            await client.SendTextMessageAsync(message.Chat.Id, "Алло");

            return Ok();
        }
    }
}
