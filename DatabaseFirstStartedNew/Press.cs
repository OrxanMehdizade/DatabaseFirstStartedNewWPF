﻿using System;
using System.Collections.Generic;

namespace DatabaseFirstStartedNew;

public partial class Press
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
