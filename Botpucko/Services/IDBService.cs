using Botpucko.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko.Services
{
    internal interface IDBService<T> where T : class
    {
        public static abstract Task<T> CreateAsync(IConfiguration Configuration);

        public Task AddGuildItemAsync(Guild guild);

        public Task<Guild> GetGuildItemAsync(int id);

        public Task ReplaceGuildDateItemAsync(int id, SessionDate date);

        public Task DeleteGuildItemAsync(int id);
    }
}
