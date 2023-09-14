using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("Api_core_product_price_cost")]
[Index("IdProduct", Name = "unq_Api_core_product_price", IsUnique = true)]
public partial class ApiCoreProductPriceCost
{
    [Key]
    public int IdProductPrice { get; set; }

    public long IdCurrency { get; set; }

    public long IdProduct { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Cost { get; set; }

    [ForeignKey("IdCurrency")]
    [InverseProperty("ApiCoreProductPriceCost")]
    public virtual ApiCoreCurrencytype IdCurrencyNavigation { get; set; } = null!;

    [ForeignKey("IdProduct")]
    [InverseProperty("ApiCoreProductPriceCost")]
    public virtual ApiCoreProduct IdProductNavigation { get; set; } = null!;
}
