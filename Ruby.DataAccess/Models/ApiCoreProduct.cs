using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_product")]
[Index("ProductCategoryId", Name = "API_core_products_category_id_4adb675a")]
public partial class ApiCoreProduct
{
    [Key]
    public long IdProduct { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(500)]
    public string Description { get; set; } = null!;

    [Column("stock")]
    public int? Stock { get; set; }

    [Column("productCategoryId")]
    public long ProductCategoryId { get; set; }

    [InverseProperty("ProductName")]
    public virtual ICollection<ApiCoreBillDetail> ApiCoreBillDetail { get; set; } = new List<ApiCoreBillDetail>();

    [InverseProperty("IdProductNavigation")]
    public virtual ApiCoreProductPriceCost? ApiCoreProductPriceCost { get; set; }

    [ForeignKey("ProductCategoryId")]
    [InverseProperty("ApiCoreProduct")]
    public virtual ApiCoreCategory ProductCategory { get; set; } = null!;
}
