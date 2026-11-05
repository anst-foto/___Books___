using System;
using System.Text.Json.Serialization;

namespace Books.DesktopApp.Models;

public class Book
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonIgnore] public string ShortId => Id.ToString()[..8];

    [JsonPropertyName("title")] public required string Title { get; set; }

    [JsonPropertyName("authors")] public string Authors { get; set; }
}