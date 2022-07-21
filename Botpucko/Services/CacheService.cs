using Botpucko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko.Services
{
    public class CacheService
    {
        private readonly Dictionary<string, Guild> Guilds;

        public CacheService()
        {
            Guilds = new Dictionary<string, Guild>();
        }

        public Guild? GetGuildIfExists(string key)
        {
            Guilds.TryGetValue(key, out Guild? guild);
            return guild;
        }

        public void InsertGuild(string key, Guild guild)
        {
            Guilds.TryAdd(key, guild);
        }
    }
}
