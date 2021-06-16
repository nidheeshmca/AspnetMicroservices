using Catalog.Api.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
 
        public CatalogContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetSection("databaseSettings")["ConnectionString"]);
            var database = client.GetDatabase(config.GetSection("databaseSettings")["DatabaseName"]);
            Products = database.GetCollection<Product>(config.GetSection("databaseSettings")["CollectionName"]);
            CatelogContextSeed.Seed(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
