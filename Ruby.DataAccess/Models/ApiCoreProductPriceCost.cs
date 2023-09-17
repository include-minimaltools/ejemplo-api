using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreProductPriceCost
{
    public int IdProductPrice { get; set; }

    public long IdCurrency { get; set; }

    public long IdProduct { get; set; }

    public decimal Price { get; set; }

    public decimal Cost { get; set; }

    public virtual ApiCoreCurrencyType IdCurrencyNavigation { get; set; } = null!;

    public virtual ApiCoreProduct IdProductNavigation { get; set; } = null!;
}
