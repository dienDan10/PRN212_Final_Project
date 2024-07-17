using System;
using System.Collections.Generic;

namespace LibraryManagement.Models;

public partial class Borrow
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? BookId { get; set; }

    public DateOnly? BorrowDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string? Status { get; set; }

    public int? Quantity { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Student? Student { get; set; }
}
