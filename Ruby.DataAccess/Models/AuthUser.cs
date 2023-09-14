using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("auth_user")]
[Index("Username", Name = "auth_user_username_6821ab7c_uniq", IsUnique = true)]
public partial class AuthUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("password")]
    [StringLength(128)]
    public string Password { get; set; } = null!;

    [Column("last_login")]
    public DateTimeOffset? LastLogin { get; set; }

    [Column("is_superuser")]
    public bool IsSuperuser { get; set; }

    [Column("username")]
    [StringLength(150)]
    public string Username { get; set; } = null!;

    [Column("first_name")]
    [StringLength(150)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(150)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(254)]
    public string Email { get; set; } = null!;

    [Column("is_staff")]
    public bool IsStaff { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("date_joined")]
    public DateTimeOffset DateJoined { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AuthUserGroups> AuthUserGroups { get; set; } = new List<AuthUserGroups>();

    [InverseProperty("User")]
    public virtual ICollection<AuthUserUserPermissions> AuthUserUserPermissions { get; set; } = new List<AuthUserUserPermissions>();

    [InverseProperty("User")]
    public virtual AuthtokenToken? AuthtokenToken { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<DjangoAdminLog> DjangoAdminLog { get; set; } = new List<DjangoAdminLog>();
}
