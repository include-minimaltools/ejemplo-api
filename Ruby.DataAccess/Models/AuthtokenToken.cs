﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ruby.DataAccess.Models;

[Table("authtoken_token")]
[Index("UserId", Name = "UQ__authtoke__B9BE370E4D26DFED", IsUnique = true)]
public partial class AuthtokenToken
{
    [Key]
    [Column("key")]
    [StringLength(40)]
    public string Key { get; set; } = null!;

    [Column("created")]
    public DateTimeOffset Created { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AuthtokenToken")]
    public virtual AuthUser User { get; set; } = null!;
}
