using Botpucko.Services;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Botpucko
{
    internal class Program
    {
        public static Task Main() => new Program().MainAsync();

        private DiscordSocketClient? _client;

        private CommandHandler? _handler;

        private AuthenticationController? _authenticationController;

        private IDBService? _iDBService;

        private CacheService? _cacheService;

        // Dependency Injection
        IServiceProvider? _services;

        CommandService? _commandService;


        public async Task MainAsync()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
            
            IConfiguration Configuration = builder.Build();

            _authenticationController = new(Configuration);

            try
            {
                _iDBService = await CosmosDBService.CreateAsync(Configuration);
            }
            catch (Exception e)
            {
                // TODO: implement cache exclusive switch here
                Console.WriteLine("Error setting up the database service. {0}", e.Message);
                return;
            }

            _cacheService = new();

            _commandService = new CommandService();

            _client = new DiscordSocketClient();

            _services = new ServiceCollection().AddSingleton(_client)
                                               .AddSingleton(_commandService)
                                               .AddSingleton(_iDBService)
                                               .AddSingleton(_cacheService)
                                               .AddSingleton<CommandHandler>()
                                               .BuildServiceProvider();
            _handler = new CommandHandler(_services, _client, _commandService);


            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, _authenticationController.GetToken());
            await _client.StartAsync();

            await _handler.InstallCommandsAsync();

            await Task.Delay(-1);

        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}