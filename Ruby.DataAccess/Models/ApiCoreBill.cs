using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreBill
{
    public long IdBill { get; set; }

    public string BillNumber { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public decimal SubTotalDolar { get; set; }

    public decimal IvaLocal { get; set; }

    public decimal TotalLocal { get; set; }

    public DateTime CreatedAt { get; set; }

    public long BillStateId { get; set; }

    public long IdCustomer { get; set; }

    public long PaymentTypeId { get; set; }

    public decimal SubTotalLocal { get; set; }

    public decimal IvaDolar { get; set; }

    public decimal TotalDolar { get; set; }

    public DateTime Date { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<ApiCoreBillDetail> ApiCoreBillDetails { get; set; } = new List<ApiCoreBillDetail>();

    public virtual ApiCoreBillState BillState { get; set; } = null!;

    public virtual ApiCoreCustomer IdCustomerNavigation { get; set; } = null!;

    public virtual ApiCorePaymenttype PaymentType { get; set; } = null!;
}
