using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko.Modules
{
    public class TimeModule : ModuleBase<SocketCommandContext>
    {
        [Command("time")]
        [Summary("Says how much time left until the next session begins.")]
        public Task TimeAsync()
        {
            DateTime dateTime = DateTime.Now;

            DateTime newDate = new(dateTime.Year, dateTime.Month, dateTime.Day, 19, 30, 0);

            int x = (int)newDate.DayOfWeek;

            int y = (int)DayOfWeek.Tuesday - x % 7;
            newDate = newDate.AddDays(y);

            if (dateTime > newDate)
                newDate = newDate.AddDays(7);
            TimeSpan span = newDate - dateTime;

            ReplyAsync(string.Format("{0}h {1}m {2}s {3}ms time left until session", (int)span.TotalHours, span.Minutes, span.Seconds, span.Milliseconds));

            return Task.CompletedTask;
        }

        [Command("time set")]
        [Summary("Sets the date and time for the !time command")]
        public Task TimeAsync(string time)
        {
            Console.WriteLine(time);
            return Task.CompletedTask;
        }
    }
}
