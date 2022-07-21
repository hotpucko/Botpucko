using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko.Modules
{
    public class RollModule : ModuleBase<SocketCommandContext>
    {
        [Command("roll")]
        [Summary("Rolls x dice of y type")]
        public Task RollAsync(string str)
        {
            const int maxDieCount = 1000;
            const int maxDieSides = 10000;

            str = str.ToLower();
            if (!str.Contains('d'))
            {
                ReplyAsync(Utility.ErrorMessages.RollModule.SyntaxError);
                return Task.CompletedTask;
            }

            string[] strings = str.Split('d');
            if (strings.Length != 2)
            {
                ReplyAsync(Utility.ErrorMessages.RollModule.SyntaxError);
                return Task.CompletedTask;
            }

            if (!int.TryParse(strings[0], out int x) || !int.TryParse(strings[1], out int y))
            {
                ReplyAsync(Utility.ErrorMessages.RollModule.SyntaxError);
                return Task.CompletedTask;
            }

            if (x <= 0 || y <= 0)
            {
                ReplyAsync(Utility.ErrorMessages.RollModule.SyntaxError);
                return Task.CompletedTask;
            }

            if (x > maxDieCount || y > maxDieSides)
            {
                ReplyAsync(String.Format(Utility.ErrorMessages.RollModule.SizeError));
                return Task.CompletedTask;
            }

            int[] rolls = new int[x];

            for (int i = 0; i < x; i++)
            {
                rolls[i] = Utility.random.Next(1, y + 1);
            }

            StringBuilder s = new();
            for (int i = 0; i < rolls.Length; i++)
            {
                s.Append(rolls[i]);
                if (i < rolls.Length - 1)
                    s.Append('\u002C');
            }

            if (x > 1)
            {
                s.Append(string.Format(" ({0})", rolls.Sum()));
            }

            ReplyAsync(string.Format("You rolled {0}.", s.ToString()));
            return Task.CompletedTask;
        }

        [Command("r")]
        [Summary("Rolls x dice of y type")]
        public Task RAsync(string str)
        {
            return RollAsync(str);
        }
    }
}
