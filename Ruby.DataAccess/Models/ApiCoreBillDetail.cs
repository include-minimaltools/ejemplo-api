using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_bill_detail")]
[Index("ProductNameId", Name = "API_core_sale_productName_id_ecc56941")]
public partial class ApiCoreBillDetail
{
    [Key]
    [Column("idBillDetail")]
    public long IdBillDetail { get; set; }

    [Column("price", TypeName = "decimal(16, 2)")]
    public decimal Price { get; set; }

    [Column("amount_products")]
    public int AmountProducts { get; set; }

    [Column("total_sale", TypeName = "decimal(16, 2)")]
    public decimal TotalSale { get; set; }

    [Column("productName_id")]
    public long ProductNameId { get; set; }

    [Column("idBill")]
    public long IdBill { get; set; }

    [Column("total", TypeName = "decimal(27, 2)")]
    public decimal? Total { get; set; }

    [Column("priceDolar", TypeName = "decimal(18, 2)")]
    public decimal PriceDolar { get; set; }

    [ForeignKey("IdBill")]
    [InverseProperty("ApiCoreBillDetail")]
    public virtual ApiCoreBill IdBillNavigation { get; set; } = null!;

    [ForeignKey("ProductNameId")]
    [InverseProperty("ApiCoreBillDetail")]
    public virtual ApiCoreProduct ProductName { get; set; } = null!;
}
