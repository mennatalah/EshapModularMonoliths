

using Shared.Data.Seed;

namespace Catalog.Data.Seed;

public class CatalogDataSeeder(CatalogDbContext dbContext) : IDataSeeder
{
    public async Task SeedAllAsync()
    {
        if(!dbContext.Products.Any())
        {
            dbContext.Products.AddRange(IntialData.Products);
            await dbContext.SaveChangesAsync();
        }
    }
}
