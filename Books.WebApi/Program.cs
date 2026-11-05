using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Books.WebApi.Data;
using Books.WebApi.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using NLog.Web;

const string apiVersion = "v1";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                          ?? throw new InvalidOperationException(
                              "Строка подключения 'DefaultConnection' не найдена в appsettings.json / appsettings.Development.json");

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlite(connectionString));

WebApplication app = builder.Build();

ILogger<Program> logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Запуск Books.WebApi");
app.Lifetime.ApplicationStopped.Register(() => logger.LogInformation("Books.WebApi остановлен"));

const string baseUrl = $"/api/{apiVersion}";

RouteGroupBuilder books = app.MapGroup($"{baseUrl}/books");

books.MapGet("/", async (DataBaseContext db, CancellationToken ct, ILogger<Program> logger) =>
{
    try
    {
        List<BookDto> items = await db.Books
            .Include(b => b.Authors)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .Select(b => new BookDto(b))
            .ToListAsync(ct);

        logger.LogInformation("Список книг запрошен; записей: {BookCount}", items.Count);
        return Results.Ok(items);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Ошибка при получении списка книг");
        throw;
    }
});

books.MapPost("/", async (BookWriteDto input, DataBaseContext db, ILogger<Program> logger) =>
{
    string title = input.Title.Trim();
    if (string.IsNullOrWhiteSpace(title) || title.Length > 300)
    {
        return Results.BadRequest("Название обязательно и должно быть не длиннее 300 символов.");
    }

    Book book = new() { Title = title, Authors = await ResolveAuthors(input.Authors, db) };

    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();
    logger.LogInformation("Создана книга {BookId}", book.Id);

    return Results.Created($"/api/v1/books/{book.Id}", new BookDto(book));
});

books.MapPut("/{id:guid}", async (Guid id, BookWriteDto input, DataBaseContext db, ILogger<Program> logger) =>
{
    Book? book = await db.Books
        .Include(b => b.Authors)
        .SingleOrDefaultAsync(b => b.Id == id);
    if (book is null)
    {
        return Results.NotFound();
    }

    string title = input.Title.Trim();
    if (title.Length is 0 or > 300)
    {
        return Results.BadRequest("Название обязательно и должно быть не длиннее 300 символов.");
    }

    book.Title = title;
    book.Authors.Clear();
    await db.SaveChangesAsync();

    book.Authors = await ResolveAuthors(input.Authors, db);
    await db.SaveChangesAsync();
    logger.LogInformation("Обновлена книга {BookId}", book.Id);

    return Results.Ok(new BookDto(book));
});

books.MapDelete("/{id:guid}", async (Guid id, DataBaseContext db, ILogger<Program> logger) =>
{
    Book? book = await db.Books
        .Include(b => b.Authors)
        .SingleOrDefaultAsync(b => b.Id == id);
    if (book is null)
    {
        return Results.NotFound();
    }

    book.Authors.Clear();
    await db.SaveChangesAsync();

    db.Books.Remove(book);
    await db.SaveChangesAsync();

    logger.LogInformation("Удалена книга {BookId}", id);

    return Results.NoContent();
});

await app.RunAsync();

return;

static async Task<List<Author>> ResolveAuthors(string? authorsText, DataBaseContext db)
{
    List<string> names = (authorsText ?? string.Empty)
        .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Where(name => name.Length > 0)
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToList();

    List<Author> result = new();
    foreach (string name in names)
    {
        Author? existing = await db.Authors.SingleOrDefaultAsync(a => a.FullName == name);
        if (existing is not null)
        {
            result.Add(existing);
            continue;
        }

        Author author = new() { FullName = name };
        db.Authors.Add(author);
        result.Add(author);
    }

    return result;
}