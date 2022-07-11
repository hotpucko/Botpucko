using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko.Exceptions
{
    internal class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message = "Could not establish database connection") : base(message)
        {
        }
    }
}
