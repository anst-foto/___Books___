using System;
using System.Collections.Generic;

namespace Books.WebApi.Models;

public class Book
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public required string Title { get; set; }

    public List<Author> Authors { get; set; } = [];
}