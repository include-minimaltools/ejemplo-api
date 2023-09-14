// Dto -> Data Transfer Object

namespace Ruby.BusinessLogic.Models;

public class ProductDto
{
    public long ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

public class ProductInputDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int ProductCategoryId { get; set; }
}