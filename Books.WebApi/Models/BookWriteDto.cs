using System.ComponentModel.DataAnnotations;

namespace Books.WebApi.Models;

public sealed class BookWriteDto
{
    [Required]
    [StringLength(300, MinimumLength = 1)]
    public string Title { get; set; } = string.Empty;

    public string Authors { get; set; } = string.Empty;
}