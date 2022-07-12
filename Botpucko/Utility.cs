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

        public static class StaticErrorMessages
        {
            public const string RollError = "Does not follow the syntax of !roll xdy where x is quantity and y is number on die.";
        }
    }
}
