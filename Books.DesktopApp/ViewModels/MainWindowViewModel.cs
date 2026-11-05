using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

using Books.DesktopApp.Models;

using DynamicData;

using NLog;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace Books.DesktopApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly HttpClient _client = App.HttpClient;
    private static readonly Uri BaseUri = new("http://localhost:5173/api/v1/books");

    private CancellationTokenSource _cts = new();

    [Reactive] private Guid? _id;
    [Reactive] private string? _title;
    [Reactive] private string? _authors;
    [Reactive] private Book? _selectedBook;
    [Reactive] private string? _status;

    public ObservableCollection<Book> Books { get; } = [];

    public bool IsEditing => SelectedBook is not null;

    public MainWindowViewModel()
    {
        this.WhenAnyValue(vm => vm.SelectedBook)
            .Subscribe(book =>
            {
                Id = book?.Id;
                Title = book?.Title;
                Authors = book?.Authors;
                this.RaisePropertyChanged(nameof(IsEditing));
            });
    }

    [ReactiveCommand]
    private async Task Load()
    {
        try
        {
            Status = "Загрузка...";
            List<Book> books = await _client.GetFromJsonAsync<List<Book>>(BaseUri, _cts.Token) ?? [];
            Books.Clear();
            Books.AddRange(books);
            Status = books.Count == 0 ? "Нет данных" : $"Загружено: {books.Count}";
            Logger.Info("Загружено книг: {BookCount}", books.Count);
        }
        catch (Exception ex)
        {
            Status = "Ошибка загрузки";
            Logger.Error(ex, "Не удалось загрузить список книг");
        }
    }

    [ReactiveCommand]
    private async Task Save()
    {
        string? title = Title?.Trim();
        if (string.IsNullOrWhiteSpace(title))
        {
            Status = "Введите название книги";
            return;
        }

        BookWriteDto input = new() { Title = title, Authors = Authors?.Trim() ?? string.Empty };

        try
        {
            using HttpResponseMessage response = IsEditing
                ? await _client.PutAsJsonAsync(new Uri($"{BaseUri}/{SelectedBook.Id}"), input, _cts.Token)
                : await _client.PostAsJsonAsync(BaseUri, input, _cts.Token);

            if (!response.IsSuccessStatusCode)
            {
                Status = $"Сохранение не выполнено: {(int)response.StatusCode}";
                Logger.Warn("Сохранение книги вернуло HTTP {StatusCode}", (int)response.StatusCode);
                return;
            }

            Book? savedBook = await response.Content.ReadFromJsonAsync<Book>(_cts.Token);
            Status = "Книга сохранена";
            await Load();
            if (savedBook is not null)
            {
                SelectedBook = Books.SingleOrDefault(book => book.Id == savedBook.Id);
            }
            else
            {
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            Status = "Ошибка сохранения";
            Logger.Error(ex, "Не удалось сохранить книгу");
        }
    }

    [ReactiveCommand]
    private async Task Delete()
    {
        if (SelectedBook is null)
        {
            Status = "Выберите книгу для удаления";
            return;
        }

        try
        {
            using HttpResponseMessage response =
                await _client.DeleteAsync(new Uri($"{BaseUri}/{SelectedBook.Id}"), _cts.Token);
            if (!response.IsSuccessStatusCode)
            {
                Status = $"Удаление не выполнено: {(int)response.StatusCode}";
                Logger.Warn("Удаление книги вернуло HTTP {StatusCode}", (int)response.StatusCode);
                return;
            }

            Status = "Книга удалена";
            await Load();
            ClearForm();
        }
        catch (Exception ex)
        {
            Status = "Ошибка удаления";
            Logger.Error(ex, "Не удалось удалить книгу");
        }
    }

    [ReactiveCommand]
    private void ClearForm()
    {
        SelectedBook = null;
        Id = null;
        Title = string.Empty;
        Authors = string.Empty;
        Status = "Форма очищена";
    }
}