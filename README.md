# Botpucko
Botpucko is a simple Discord bot utilizing the Discord.net framework.

## Setup
1. Clone project
2. [Install Discord.Net](https://discordnet.dev/guides/getting_started/installing.html)
   1. Visual Studio 2022
      1. Right click `Dependencies` -> `Manage Nuget Packages`
      2. Search for, and install `Discord.Net`
   2. CLI
      1. Navigate to `*.csproj`
      2. Enter `dotnet add package Discord.Net`
3. [Setup Discord bot](https://discordnet.dev/guides/getting_started/first-bot.html)
   1. [Creating a Discord bot](https://discordnet.dev/guides/getting_started/first-bot.html#creating-a-discord-bot)
      1. Visit the [Discord Application Portal](https://discord.com/developers/applications/)
      2. Create a new application
      3. Give the Application a name (This will be the bot's initial username)
      4. On the left-hand side, under `settings`, click `bot`
      5. Click `add bot`
   2. [Adding your bot to a server](https://discordnet.dev/guides/getting_started/first-bot.html#adding-your-bot-to-a-server)
      1. Open your bots application on the [Discord Applications Portal](https://discord.com/developers/applications/)
      2. On the left-hand side, under `settings`, click `OAuth2`
      3. Scroll down to `OAuth2 URL Generator` and under `scopes` tick `bot`.
      4. Scroll down further to `Bot Permissions` and select the permissions that you wish to assign your bot [Minimum Bot permissions](#minimum-bot-permissions)
      5. Open the generated Authotization URL in your browser
      6. Select a server
      7. Click on Authorize
3. Setup Secret.json
   1. Visual Studio 2022
      1. Right click project -> Manage User Secrets
      2. Add your Discord Bot Token as JSON key value pair `{"Authentication:Token": "Your-key-here"}`
      3. Go To 'Connected Services' and configure `Secrets.json` as a service
   2. CLI
      1. In the CLI write `dotnet user-secrets set Authentication:Token your-key-here`

## Minimum Bot Permissions
The current recommended minimum bot permissions are 3072.
- [x] Read Messages/View Channels
- [x] Send Messages

## Requirements
.Net 6.0

## Features
- [x] `!Roll xdy`, rolls x dy dice. Example usage: `!Roll 3d6`, output: ``. Alias `!r xdy`.
- [x] `!time` prints the time remaining until the session. Example usage `!time`, output `35 hours 15 minutes left until session`.
- [ ] `!time set d hhmm` (server owner restriction) sets the session time for the `!time` command to a supplied day and time. Example usage `!time set 3 2030`, output: sets the session time to thursday 20:30.
