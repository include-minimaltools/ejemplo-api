using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreCurrencyExchange
{
    public long IdCurrencyExchange { get; set; }

    public decimal ExchangeRateLocal { get; set; }

    public long IdCurrency { get; set; }

    public decimal ExchangeRateDolar { get; set; }

    public virtual ApiCoreCurrencyType IdCurrencyNavigation { get; set; } = null!;
}
