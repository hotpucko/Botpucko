using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko
{
    internal class Utility
    {
        public static readonly Random random = new();

        public static class ErrorMessages
        {
            public static class RollModule
            {
                public const string SyntaxError = "Does not follow the syntax of !roll xdy where x is quantity and y is number on die.";
                public const string SizeError = "Max dice quantity or max dice sides exceeded.";
            }

            public static class TimeModule
            {

            }
        }
    }
}
