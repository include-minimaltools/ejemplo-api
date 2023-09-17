using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCorePaymenttype
{
    public long PaymentTypeId { get; set; }

    public string PaymentType { get; set; } = null!;

    public virtual ICollection<ApiCoreBill> ApiCoreBills { get; set; } = new List<ApiCoreBill>();
}
