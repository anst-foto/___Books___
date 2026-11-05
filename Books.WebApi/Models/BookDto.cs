using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Books.WebApi.Models;

public class BookDto
{
    [JsonPropertyName("id")] public Guid Id { get; }

    [JsonPropertyName("title")] public string Title { get; }

    [JsonPropertyName("authors")] public string Authors { get; }

    public BookDto(Book book)
    {
        Id = book.Id;
        Title = book.Title;
        Authors = string.Join(", ", book.Authors.Select(a => a.FullName));
    }
}