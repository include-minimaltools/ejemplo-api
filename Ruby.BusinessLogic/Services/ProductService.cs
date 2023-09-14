using Ruby.BusinessLogic.Models;
using Ruby.DataAccess.Models;

namespace Ruby.BusinessLogic.Services;

public class ProductService
{
    private readonly RubyContext _dbContext;

    public ProductService(RubyContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<ProductDto> GetProducts()
    {
        return _dbContext.ApiCoreProduct.Select(x => new ProductDto
        {
            ProductId = x.IdProduct,
            Name = x.Name,
            Description = x.Description,
        })
        .Take(10)
        .ToList();
    }

    public void CreateProduct(ProductInputDto newProduct)
    {
        ApiCoreProduct product = new()
        {
            Name = newProduct.Name,
            Description = newProduct.Description,
            ProductCategoryId = newProduct.ProductCategoryId,
            Stock = 0,
        };

        _dbContext.ApiCoreProduct.Add(product);
        _dbContext.SaveChanges();
    }
}