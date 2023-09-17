using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreCategory
{
    public long ProductCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ApiCoreProduct> ApiCoreProducts { get; set; } = new List<ApiCoreProduct>();
}
