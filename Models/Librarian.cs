using System;
using System.Collections.Generic;

namespace LibraryManagement.Models;

public partial class Librarian
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
