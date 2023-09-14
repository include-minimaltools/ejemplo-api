using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_paymenttype")]
public partial class ApiCorePaymenttype
{
    [Key]
    [Column("paymentTypeId")]
    public long PaymentTypeId { get; set; }

    [Column("paymentType")]
    [StringLength(100)]
    public string PaymentType { get; set; } = null!;

    [InverseProperty("PaymentType")]
    public virtual ICollection<ApiCoreBill> ApiCoreBill { get; set; } = new List<ApiCoreBill>();
}
