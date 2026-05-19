

namespace Catalog.Products.Features.CreateProduct;
public record CreateProductCommand(ProductDto Product) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);
public class CreateProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command
        , CancellationToken cancellationToken)
    {
        var product = CreateProductNewProduct(command.Product);
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        return new CreateProductResult(product.Id);
    }
    private Product CreateProductNewProduct(ProductDto productDto)
    {
        return Product.Create(
            Guid.NewGuid(),
            productDto.Name,
            productDto.Category,
            productDto.Description,
            productDto.Price,
            productDto.ImageFile);
    }
}
