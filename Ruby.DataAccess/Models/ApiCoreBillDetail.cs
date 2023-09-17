using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreBillDetail
{
    public long IdBillDetail { get; set; }

    public decimal Price { get; set; }

    public int AmountProducts { get; set; }

    public decimal TotalSale { get; set; }

    public long ProductNameId { get; set; }

    public long IdBill { get; set; }

    public decimal? Total { get; set; }

    public decimal PriceDolar { get; set; }

    public virtual ApiCoreBill IdBillNavigation { get; set; } = null!;

    public virtual ApiCoreProduct ProductName { get; set; } = null!;
}
