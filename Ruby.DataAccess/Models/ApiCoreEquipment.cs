using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("API_core_equipment")]
[Index("IdEquipmentCategoryId", Name = "API_core_equipment_id_equipment_category_id_d8c8e3f5")]
public partial class ApiCoreEquipment
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column("id_equipment_category_id")]
    public long IdEquipmentCategoryId { get; set; }

    [ForeignKey("IdEquipmentCategoryId")]
    [InverseProperty("ApiCoreEquipment")]
    public virtual ApiCoreEquipmentCategory IdEquipmentCategory { get; set; } = null!;
}
