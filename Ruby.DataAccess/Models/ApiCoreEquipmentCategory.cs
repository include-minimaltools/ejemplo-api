using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreEquipmentCategory
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<ApiCoreEquipment> ApiCoreEquipments { get; set; } = new List<ApiCoreEquipment>();
}
