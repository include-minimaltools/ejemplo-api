using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_customer")]
[Index("TypeCustomerId", Name = "API_core_customer_customer_Type_id_1b9694ba")]
public partial class ApiCoreCustomer
{
    [Key]
    public long IdCustomer { get; set; }

    [Column("fullName")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("typeCustomerId")]
    public long TypeCustomerId { get; set; }

    [InverseProperty("IdCustomerNavigation")]
    public virtual ICollection<ApiCoreBill> ApiCoreBill { get; set; } = new List<ApiCoreBill>();

    [ForeignKey("TypeCustomerId")]
    [InverseProperty("ApiCoreCustomer")]
    public virtual ApiCoreTypecustomer TypeCustomer { get; set; } = null!;
}
