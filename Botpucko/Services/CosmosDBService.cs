using Botpucko.Exceptions;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Botpucko.Models;

namespace Botpucko.Services
{
    internal class CosmosDBService : IDBService
    {
        private readonly string EndpointURI;
        private readonly string PrimaryKey;

        private readonly CosmosClient cosmosClient;

        private Database? database;

        private Container? container;

        private const string DATABASE_ID = "rpDatabase";
        private const string CONTAINER_ID = "rpContainer";
        private const string CONTAINER_PARTITION_KEY_ID = "/Id";

        private readonly IConfiguration Configuration;

        private CosmosDBService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
            EndpointURI = Configuration["Storage:Azure:CosmosDB:URI"];
            PrimaryKey = Configuration["Storage:Azure:CosmosDB:PrimaryKey"];
            cosmosClient = new(EndpointURI, PrimaryKey);
        }

        public static async Task<IDBService> CreateAsync(IConfiguration Configuration)
        {
            CosmosDBService service = new(Configuration);
            await service.CreateDatabaseAsync();
            if (service.database == null)
                throw new DatabaseConnectionException();
            await service.CreateContainersAsync();
            return service;
        }

        private async Task CreateDatabaseAsync()
        {
            database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DATABASE_ID);
        }

        private async Task CreateContainersAsync()
        {
            container = database == null ? null : await database.CreateContainerIfNotExistsAsync(CONTAINER_ID, CONTAINER_PARTITION_KEY_ID);
        }

        public async Task AddGuildItemAsync(Guild Guild)
        {
            try
            {
                ItemResponse<Guild> guildResponse = await this.container.ReadItemAsync<Guild>(Guild.Id, new PartitionKey(Guild.Id));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ItemResponse<Guild> guildResponse = await this.container.CreateItemAsync<Guild>(Guild, new PartitionKey(Guild.Id));
                Console.WriteLine("Created item in database with id: {0}, operation consumed {1} RUs.", guildResponse.Resource.Id, guildResponse.RequestCharge);
            }
        }

        public async Task<Guild?> GetGuildItemAsync(string Id)
        {
            var sqlQueryText = $"SELECT * FROM c WHERE c.Id = '{Id}'";

            Console.WriteLine("Running Query: {0}", sqlQueryText);

            QueryDefinition queryDefinition = new(sqlQueryText);
            using FeedIterator<Guild> queryResultIterator = this.container.GetItemQueryIterator<Guild>(queryDefinition);

            List<Guild> guilds = new();

            while (queryResultIterator.HasMoreResults)
            {
                FeedResponse<Guild> currentResultSet = await queryResultIterator.ReadNextAsync();
                foreach (Guild Guild in currentResultSet)
                {
                    guilds.Add(Guild);
                    Console.WriteLine("Read {0}", Guild);
                }
            }

            if (guilds.Count <= 0)
                return null;

            return guilds[0];
        }

        public async Task ReplaceGuildDateItemAsync(string id, SessionDate date)
        {
            ItemResponse<Guild> guildResponse = await this.container.ReadItemAsync<Guild>(id.ToString(), new PartitionKey(id));
            Guild itemBody = guildResponse.Resource;

            SessionDate oldDate = itemBody.Date;
            itemBody.Date = date;

            guildResponse = await this.container.ReplaceItemAsync<Guild>(itemBody, itemBody.Id, new PartitionKey(itemBody.Id));
            Console.WriteLine("Updated Guild {0} to {1} (was {2}).", guildResponse.Resource.Id, guildResponse.Resource.Date, oldDate);
        }

        public async Task DeleteGuildItemAsync(string id)
        {
            ItemResponse<Guild> itemResponse = await this.container.DeleteItemAsync<Guild>(id.ToString(), new PartitionKey(id));
            Console.WriteLine("Deleted Guild [{0}].", itemResponse.Resource.Id);
        }
    }
}
