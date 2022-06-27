using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko
{
    internal class AuthenticationController
    {
        private readonly IConfiguration Configuration;
        
        public AuthenticationController(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public string GetToken()
        {
            //https://stackoverflow.com/a/69216632
            return this.Configuration["Authentication:Token"];
        }

    }
}
