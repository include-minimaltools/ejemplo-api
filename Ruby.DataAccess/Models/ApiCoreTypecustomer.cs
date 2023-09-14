using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_typecustomer")]
public partial class ApiCoreTypecustomer
{
    [Key]
    [Column("typeCustomerId")]
    public long TypeCustomerId { get; set; }

    [Column("customerType")]
    [StringLength(500)]
    public string CustomerType { get; set; } = null!;

    [InverseProperty("TypeCustomer")]
    public virtual ICollection<ApiCoreCustomer> ApiCoreCustomer { get; set; } = new List<ApiCoreCustomer>();
}
