using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brand = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var items in brand)
                    {
                        context.ProductBrands.Add(items);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var type = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var items in type)
                    {
                        context.ProductTypes.Add(items);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var product = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach (var items in product)
                    {
                        context.Products.Add(items);
                    }
                    await context.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}