using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_bill_state")]
public partial class ApiCoreBillState
{
    [Key]
    [Column("billStateId")]
    public long BillStateId { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [InverseProperty("BillState")]
    public virtual ICollection<ApiCoreBill> ApiCoreBill { get; set; } = new List<ApiCoreBill>();
}
