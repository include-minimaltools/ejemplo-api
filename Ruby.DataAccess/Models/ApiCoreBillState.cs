using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreBillState
{
    public long BillStateId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ApiCoreBill> ApiCoreBills { get; set; } = new List<ApiCoreBill>();
}
