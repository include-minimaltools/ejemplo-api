using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class ApiCoreEquipment
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long IdEquipmentCategoryId { get; set; }

    public virtual ApiCoreEquipmentCategory IdEquipmentCategory { get; set; } = null!;
}
