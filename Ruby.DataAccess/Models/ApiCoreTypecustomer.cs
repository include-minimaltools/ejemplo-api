using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreTypecustomer
{
    public long TypeCustomerId { get; set; }

    public string CustomerType { get; set; } = null!;

    public virtual ICollection<ApiCoreCustomer> ApiCoreCustomers { get; set; } = new List<ApiCoreCustomer>();
}
