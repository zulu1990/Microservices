﻿using Catalog.API.Entities;
using Catalog.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Product> Products { get; set; }


    public CatalogContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);

        Products = database.GetCollection<Product>(settings.Value.CollectionName);

        CatalogContextSeed.SeedData(Products);
    }


    
}
