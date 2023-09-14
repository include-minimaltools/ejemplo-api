using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_bill")]
[Index("BillNumber", Name = "UQ__API_core__8C43111113BF09D5", IsUnique = true)]
public partial class ApiCoreBill
{
    [Key]
    [Column("idBill")]
    public long IdBill { get; set; }

    [Column("billNumber")]
    [StringLength(20)]
    public string BillNumber { get; set; } = null!;

    [Column("customerName")]
    [StringLength(500)]
    public string CustomerName { get; set; } = null!;

    [Column("phoneNumber")]
    [StringLength(9)]
    public string PhoneNumber { get; set; } = null!;

    [Column("subTotalDolar", TypeName = "decimal(18, 2)")]
    public decimal SubTotalDolar { get; set; }

    [Column("ivaLocal", TypeName = "decimal(18, 2)")]
    public decimal IvaLocal { get; set; }

    [Column("totalLocal", TypeName = "decimal(18, 2)")]
    public decimal TotalLocal { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("billStateId")]
    public long BillStateId { get; set; }

    [Column("idCustomer")]
    public long IdCustomer { get; set; }

    [Column("paymentTypeId")]
    public long PaymentTypeId { get; set; }

    [Column("subTotalLocal", TypeName = "decimal(18, 2)")]
    public decimal SubTotalLocal { get; set; }

    [Column("ivaDolar", TypeName = "decimal(18, 2)")]
    public decimal IvaDolar { get; set; }

    [Column("totalDolar", TypeName = "decimal(18, 2)")]
    public decimal TotalDolar { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("created_by")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [InverseProperty("IdBillNavigation")]
    public virtual ICollection<ApiCoreBillDetail> ApiCoreBillDetail { get; set; } = new List<ApiCoreBillDetail>();

    [ForeignKey("BillStateId")]
    [InverseProperty("ApiCoreBill")]
    public virtual ApiCoreBillState BillState { get; set; } = null!;

    [ForeignKey("IdCustomer")]
    [InverseProperty("ApiCoreBill")]
    public virtual ApiCoreCustomer IdCustomerNavigation { get; set; } = null!;

    [ForeignKey("PaymentTypeId")]
    [InverseProperty("ApiCoreBill")]
    public virtual ApiCorePaymenttype PaymentType { get; set; } = null!;
}
