using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_equipment_category")]
public partial class ApiCoreEquipmentCategory
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(500)]
    public string Description { get; set; } = null!;

    [InverseProperty("IdEquipmentCategory")]
    public virtual ICollection<ApiCoreEquipment> ApiCoreEquipment { get; set; } = new List<ApiCoreEquipment>();
}
