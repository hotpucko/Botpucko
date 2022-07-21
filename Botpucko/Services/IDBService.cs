using Botpucko.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko.Services
{
    public interface IDBService
    {
        public static abstract Task<IDBService> CreateAsync(IConfiguration Configuration);

        public Task AddGuildItemAsync(Guild guild);

        public Task<Guild> GetGuildItemAsync(string id);

        public Task ReplaceGuildDateItemAsync(string id, SessionDate date);

        public Task DeleteGuildItemAsync(string  id);
    }
}
