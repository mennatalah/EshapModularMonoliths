

namespace Catalog.Data.Seed;

public static class IntialData
{
    public static List<Product> Products => new List<Product>
        {
             Product.Create(Guid.NewGuid(), "Apple iPhone 13",new List<string> { "Electronics", "Mobile Phones" },"The latest iPhone with A15 Bionic chip, improved camera, and longer battery life.",
                999.99m, "iphone13.jpg"),
             Product.Create(Guid.NewGuid(), "Dell XPS 13", new List<string> { "Electronics", "Laptops" }, "A high-performance laptop with a sleek design, perfect for work and entertainment.",
                1199.99m, "dell_xps13.jpg"),
             Product.Create(Guid.NewGuid(), "Samsung QLED TV", new List<string> { "Electronics", "Televisions" }, "Experience stunning visuals with Samsung's QLED technology and smart features.",
                 2000.99m, "Samsung.jpg" )
        };
}
