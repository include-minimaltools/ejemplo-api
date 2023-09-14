using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_category")]
public partial class ApiCoreCategory
{
    [Key]
    [Column("productCategoryId")]
    public long ProductCategoryId { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(500)]
    public string Description { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("ProductCategory")]
    public virtual ICollection<ApiCoreProduct> ApiCoreProduct { get; set; } = new List<ApiCoreProduct>();
}
