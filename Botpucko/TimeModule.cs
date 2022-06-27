using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko
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
            
            int y = (((int)DayOfWeek.Tuesday)) - x % 7;
            newDate = newDate.AddDays(y);

            if (dateTime > newDate)
                newDate = newDate.AddDays(7);
            TimeSpan span = newDate - dateTime;

            ReplyAsync(String.Format("{0}h {1}m time left until session", (int)span.TotalHours, span.Minutes));

            return Task.CompletedTask;
        } 
    }
}
