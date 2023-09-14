using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("auth_permission")]
[Index("ContentTypeId", Name = "auth_permission_content_type_id_2f476e4b")]
public partial class AuthPermission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("content_type_id")]
    public int ContentTypeId { get; set; }

    [Column("codename")]
    [StringLength(100)]
    public string Codename { get; set; } = null!;

    [InverseProperty("Permission")]
    public virtual ICollection<AuthGroupPermissions> AuthGroupPermissions { get; set; } = new List<AuthGroupPermissions>();

    [InverseProperty("Permission")]
    public virtual ICollection<AuthUserUserPermissions> AuthUserUserPermissions { get; set; } = new List<AuthUserUserPermissions>();

    [ForeignKey("ContentTypeId")]
    [InverseProperty("AuthPermission")]
    public virtual DjangoContentType ContentType { get; set; } = null!;
}
