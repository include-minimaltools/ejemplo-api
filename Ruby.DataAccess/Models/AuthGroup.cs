using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("auth_group")]
[Index("Name", Name = "auth_group_name_a6ea08ec_uniq", IsUnique = true)]
public partial class AuthGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(150)]
    public string Name { get; set; } = null!;

    [InverseProperty("Group")]
    public virtual ICollection<AuthGroupPermissions> AuthGroupPermissions { get; set; } = new List<AuthGroupPermissions>();

    [InverseProperty("Group")]
    public virtual ICollection<AuthUserGroups> AuthUserGroups { get; set; } = new List<AuthUserGroups>();
}
