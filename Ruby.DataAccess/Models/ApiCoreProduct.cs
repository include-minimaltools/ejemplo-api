using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreProduct
{
    public long IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? Stock { get; set; }

    public long ProductCategoryId { get; set; }

    public virtual ICollection<ApiCoreBillDetail> ApiCoreBillDetails { get; set; } = new List<ApiCoreBillDetail>();

    public virtual ApiCoreProductPriceCost? ApiCoreProductPriceCost { get; set; }

    public virtual ApiCoreCategory ProductCategory { get; set; } = null!;
}
