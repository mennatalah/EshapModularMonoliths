namespace Catalog.Products.Models;

public class Product : Aggregate<Guid>
{
    public string Name { get; private set; } = default!;
    public List<string> Category { get; private set; } = new();
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }
    public string ImageFile { get; private set; } = default!;

    public static Product Create(
        Guid id,
        string name, 
        List<string> category,
        string description, 
        decimal price,
        string imageFile)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price, nameof(price));

        var product =  new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Category = category,
            Description = description,
            Price = price,
            ImageFile = imageFile
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }

    public void Update(
            string name,
            List<string> category,
            string description,
            decimal price,
            string imageFile)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price, nameof(price));

        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;

        if(Price != price)
        {
            Price = price;
            AddDomainEvent(new ProductPriceChangedEvent(this));
        }
    }
}
