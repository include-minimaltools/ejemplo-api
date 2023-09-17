﻿using System;
using System.Collections.Generic;

namespace Ruby.DataAccess.Models;

public partial class AuthtokenToken
{
    public string Key { get; set; } = null!;

    public DateTimeOffset Created { get; set; }

    public int UserId { get; set; }

    public virtual AuthUser User { get; set; } = null!;
}
