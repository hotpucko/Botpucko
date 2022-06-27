# Botpucko
Botpucko is a simple Discord bot utilizing the Discord.net framework.

## Setup
1. Clone project
2. [Setup Discord bot](https://discordnet.dev/guides/getting_started/first-bot.html)
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
      4. Scroll down further to `Bot Permissions` and select the permissions that you wish to assign your bot with *link to recommended Bot permissions here*
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

## Recommended Bot Permissions
