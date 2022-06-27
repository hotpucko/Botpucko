using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace Botpucko
{
    internal class Program
    {
        public static Task Main() => new Program().MainAsync();

        private DiscordSocketClient? _client;

        private CommandHandler? _handler;

        private AuthenticationController? _authenticationController;

        public async Task MainAsync()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<Program>();

            _authenticationController = new(builder.Build());

            _client = new DiscordSocketClient();

            _handler = new CommandHandler(_client, new Discord.Commands.CommandService());

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