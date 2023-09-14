using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_currencytype")]
public partial class ApiCoreCurrencytype
{
    [Key]
    public long IdCurrency { get; set; }

    [StringLength(50)]
    public string Currency { get; set; } = null!;

    [InverseProperty("IdCurrencyNavigation")]
    public virtual ICollection<ApiCoreProductPriceCost> ApiCoreProductPriceCost { get; set; } = new List<ApiCoreProductPriceCost>();

    [InverseProperty("IdCurrencyNavigation")]
    public virtual ICollection<CurrencyExchange> CurrencyExchange { get; set; } = new List<CurrencyExchange>();
}
