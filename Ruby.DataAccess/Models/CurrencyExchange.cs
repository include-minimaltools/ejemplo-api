using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

public partial class CurrencyExchange
{
    [Key]
    public long IdCurrencyExchange { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ExchangeRate { get; set; }

    public long IdCurrency { get; set; }

    [ForeignKey("IdCurrency")]
    [InverseProperty("CurrencyExchange")]
    public virtual ApiCoreCurrencytype IdCurrencyNavigation { get; set; } = null!;
}
