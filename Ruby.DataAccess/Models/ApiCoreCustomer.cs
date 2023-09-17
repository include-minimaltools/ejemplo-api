using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreCustomer
{
    public long IdCustomer { get; set; }

    public string FullName { get; set; } = null!;

    public long TypeCustomerId { get; set; }

    public virtual ICollection<ApiCoreBill> ApiCoreBills { get; set; } = new List<ApiCoreBill>();

    public virtual ApiCoreTypecustomer TypeCustomer { get; set; } = null!;
}
