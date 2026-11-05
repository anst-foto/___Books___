using System;
using System.Collections.Generic;

namespace Books.WebApi.Models;

public class Author
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public required string FullName { get; set; }

    public List<Book> Books { get; set; } = [];
}