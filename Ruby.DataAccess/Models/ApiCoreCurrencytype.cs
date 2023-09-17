using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreCurrencyType
{
    public long IdCurrency { get; set; }

    public string Currency { get; set; } = null!;

    public virtual ICollection<ApiCoreCurrencyExchange> ApiCoreCurrencyExchanges { get; set; } = new List<ApiCoreCurrencyExchange>();

    public virtual ICollection<ApiCoreProductPriceCost> ApiCoreProductPriceCosts { get; set; } = new List<ApiCoreProductPriceCost>();
}
