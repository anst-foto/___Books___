<!-- Solution2MD generated file -->
# Содержимое решения

- Решение: `Books.slnx`
- Проектов: 2
- Файлов в структуре: 36

## Проекты

- `Books.DesktopApp/Books.DesktopApp.csproj`
- `Books.WebApi/Books.WebApi.csproj`

## Структура решения

```
Books/
.idea/
  .idea.Books/
    .idea/
      .gitignore
      avalonia.xml
      dataSources.xml
      indexLayout.xml
      jsonSchemas.xml
      misc.xml
books.db
Books.DesktopApp/
  App.axaml
  App.axaml.cs
  app.manifest
  Assets/
    avalonia-logo.ico
  Books.DesktopApp.csproj
  Models/
    Book.cs
  NLog.config
  Program.cs
  ViewLocator.cs
  ViewModels/
    MainWindowViewModel.cs
    ViewModelBase.cs
  Views/
    MainWindow.axaml
    MainWindow.axaml.cs
Books.slnx
Books.WebApi/
  appsettings.Development.json
  appsettings.json
  Books.WebApi.csproj
  Books.WebApi.http
  Data/
    DataBaseContext.cs
    DataBaseContextFactory.cs
  Migrations/
    20261105154202_Initial.cs
    20261105154202_Initial.Designer.cs
    DataBaseContextModelSnapshot.cs
  Models/
    Author.cs
    Book.cs
    BookDto.cs
  NLog.config
  Program.cs
  Properties/
    launchSettings.json
```

## Содержимое файлов

### `.idea/.idea.Books/.idea/.gitignore`

```text
# Default ignored files
/shelf/
/workspace.xml
# Editor-based HTTP Client requests
/httpRequests/
# Rider ignored files
/modules.xml
/contentModel.xml
/projectSettingsUpdater.xml
/.idea.Books.iml
# Ignored default folder with query files
/queries/
# Datasource local storage ignored files
/dataSources/
/dataSources.local.xml
```

### `.idea/.idea.Books/.idea/avalonia.xml`

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project version="4">
  <component name="AvaloniaProject">
    <option name="projectPerEditor">
      <map>
        <entry key="Books.DesktopApp/Views/MainWindow.axaml" value="Books.DesktopApp/Books.DesktopApp.csproj" />
      </map>
    </option>
  </component>
</project>
```

### `.idea/.idea.Books/.idea/dataSources.xml`

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project version="4">
  <component name="DataSourceManagerImpl" format="xml" multifile-model="true">
    <data-source source="LOCAL" name="books.db" uuid="22e5f91a-2454-4b2a-9847-a16666dec85f">
      <driver-ref>sqlite.xerial</driver-ref>
      <synchronize>true</synchronize>
      <jdbc-driver>org.sqlite.JDBC</jdbc-driver>
      <jdbc-url>jdbc:sqlite:C:\Programming\Books\books.db</jdbc-url>
      <working-dir>$ProjectFileDir$</working-dir>
    </data-source>
  </component>
</project>
```

### `.idea/.idea.Books/.idea/indexLayout.xml`

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project version="4">
  <component name="UserContentModel">
    <attachedFolders />
    <explicitIncludes />
    <explicitExcludes />
  </component>
</project>
```

### `.idea/.idea.Books/.idea/jsonSchemas.xml`

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project version="4">
  <component name="JsonSchemaMappingsProjectConfiguration">
    <state>
      <map>
        <entry key="appsettings.json">
          <value>
            <SchemaInfo>
              <option name="name" value="appsettings.json" />
              <option name="relativePathToSchema" value="https://www.schemastore.org/appsettings.json" />
              <option name="applicationDefined" value="true" />
              <option name="patterns">
                <list>
                  <Item>
                    <option name="path" value="Books.WebApi/appsettings.json" />
                  </Item>
                  <Item>
                    <option name="path" value="Books.WebApi/appsettings.Development.json" />
                  </Item>
                </list>
              </option>
            </SchemaInfo>
          </value>
        </entry>
      </map>
    </state>
  </component>
</project>
```

### `.idea/.idea.Books/.idea/misc.xml`

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project version="4">
  <component name="DebugServers">
    <config name="Config" />
  </component>
</project>
```

### `books.db`

> Пропущен бинарный файл (53 248 байт).

### `Books.DesktopApp/App.axaml`

```text
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             x:Class="Books.DesktopApp.App"
             xmlns:local="using:Books.DesktopApp"
             RequestedThemeVariant="Default">
             <!-- "Default" ThemeVariant follows system theme variant. "Dark" or "Light" are other available options. -->

    <Application.DataTemplates>
        <local:ViewLocator/>
    </Application.DataTemplates>
  
    <Application.Styles>
        <FluentTheme />
    </Application.Styles>
</Application>
```

### `Books.DesktopApp/App.axaml.cs`

```csharp
using System.Net.Http;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Books.DesktopApp.ViewModels;
using Books.DesktopApp.Views;

namespace Books.DesktopApp;

public partial class App : Application
{
    public static HttpClient HttpClient { get; } = new HttpClient();
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
```

### `Books.DesktopApp/app.manifest`

```text
﻿<?xml version="1.0" encoding="utf-8"?>
<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">
  <!-- This manifest is used on Windows only.
       Don't remove it as it might cause problems with window transparency and embedded controls.
       For more details visit https://learn.microsoft.com/en-us/windows/win32/sbscs/application-manifests -->
  <assemblyIdentity version="1.0.0.0" name="Books.DesktopApp.Desktop"/>

  <compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
    <application>
      <!-- A list of the Windows versions that this application has been tested on
           and is designed to work with. Uncomment the appropriate elements
           and Windows will automatically select the most compatible environment. -->

      <!-- Windows 10 -->
      <supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}" />
    </application>
  </compatibility>
</assembly>
```

### `Books.DesktopApp/Assets/avalonia-logo.ico`

> Пропущен бинарный файл (175 875 байт).

### `Books.DesktopApp/Books.DesktopApp.csproj`

```xml
﻿<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <OutputType>WinExe</OutputType>
        <TargetFramework>net10.0</TargetFramework>
        <Nullable>enable</Nullable>
        <ApplicationManifest>app.manifest</ApplicationManifest>
        <AvaloniaUseCompiledBindingsByDefault>true</AvaloniaUseCompiledBindingsByDefault>
        <ImplicitUsings>disable</ImplicitUsings>
    </PropertyGroup>

    <ItemGroup>
        <AvaloniaResource Include="Assets\**" />
    </ItemGroup>

    <ItemGroup>
        <PackageReference Include="Avalonia" Version="12.0.4" />
        <PackageReference Include="Avalonia.Desktop" Version="12.0.4" />
        <PackageReference Include="Avalonia.Themes.Fluent" Version="12.0.4" />
        <PackageReference Include="Avalonia.Fonts.Inter" Version="12.0.4" />
        <PackageReference Include="NLog" Version="6.2.2" />
        
        <PackageReference Include="ReactiveUI.Avalonia" Version="12.0.3" />
        <PackageReference Include="ReactiveUI.SourceGenerators" Version="4.2.0" />
    </ItemGroup>

    <ItemGroup>
        <None Update="NLog.config" CopyToOutputDirectory="PreserveNewest" />
    </ItemGroup>
</Project>
```

### `Books.DesktopApp/Models/Book.cs`

```csharp
using System;
using System.Text.Json.Serialization;

namespace Books.DesktopApp.Models;

public class Book
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonIgnore]
    public string ShortId => Id.ToString()[..8];
    
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    
    [JsonPropertyName("authors")]
    public string Authors { get; set; }
}
```

### `Books.DesktopApp/NLog.config`

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      autoReload="true"
      throwConfigExceptions="true">
    <targets>
        <target xsi:type="File"
                name="file"
                fileName="${basedir}/logs/Books.DesktopApp-${shortdate}.log"
                layout="${longdate}|${level:uppercase=true}|${logger}|${message} ${exception:format=tostring}" />
        <target xsi:type="Console"
                name="criticalConsole"
                error="true"
                layout="${longdate}|${level:uppercase=true}|${logger}|${message} ${exception:format=tostring}" />
    </targets>
    <rules>
        <logger name="*" minlevel="Info" writeTo="file" />
        <logger name="*" minlevel="Fatal" maxlevel="Fatal" writeTo="criticalConsole" />
    </rules>
</nlog>
```

### `Books.DesktopApp/Program.cs`

```csharp
﻿using System;
using System.IO;
using Avalonia;
using NLog;
using ReactiveUI.Avalonia;

namespace Books.DesktopApp;

sealed class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var logger = LogManager.Setup()
            .LoadConfigurationFromFile(Path.Combine(AppContext.BaseDirectory, "NLog.config"))
            .GetCurrentClassLogger();

        try
        {
            logger.Info("Запуск Books.DesktopApp");
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
            logger.Info("Books.DesktopApp завершил работу");
        }
        catch (Exception ex)
        {
            logger.Fatal(ex, "Критическая ошибка Books.DesktopApp");
            throw;
        }
        finally
        {
            LogManager.Shutdown();
        }
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI(_ => { });
}
```

### `Books.DesktopApp/ViewLocator.cs`

```csharp
using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Books.DesktopApp.ViewModels;

namespace Books.DesktopApp;

/// <summary>
/// Given a view model, returns the corresponding view if possible.
/// </summary>
[RequiresUnreferencedCode(
    "Default implementation of ViewLocator involves reflection which may be trimmed away.",
    Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is null)
            return null;

        var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
```

### `Books.DesktopApp/ViewModels/MainWindowViewModel.cs`

```csharp
﻿using System;
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
    
    private HttpClient _client = App.HttpClient;

    private static readonly Uri BaseUri = new("http://localhost:5173/api/v1/books");
    
    private CancellationTokenSource _cts;

    [Reactive] private Guid? _id;
    [Reactive] private string? _title;
    [Reactive] private string? _authors;
    [Reactive] private Book? _selectedBook;
    
    [Reactive] private string? _status;
    
    public ObservableCollection<Book> Books { get; } = [];

    public MainWindowViewModel()
    {
        this.WhenAnyValue(vm => vm.SelectedBook)
            .Subscribe( book =>
            {
                Id = book?.Id;
                Title = book?.Title;
                Authors = book?.Authors;
            });
    }

    [ReactiveCommand]
    private async Task Load()
    {
        _cts = new CancellationTokenSource();
        //_cts.CancelAfter(TimeSpan.FromSeconds(15));

        try
        {
            Status = "Загрузка...";
            Logger.Info("Начата загрузка списка книг из API {ApiUri}", BaseUri);
        
            var json = await _client.GetFromJsonAsync<IEnumerable<Book>>(BaseUri, _cts.Token);
            var books = json?.ToList() ?? [];
        
            if (books.Count == 0)
            {
                Books.Clear();
                Status = "Нет данных";
                Logger.Info("API вернул пустой список книг");
                return;
            }
        
            Books.Clear();
            Books.AddRange(books);
        
            Status = "Готово";
            Logger.Info("Загружено книг: {BookCount}", books.Count);
        }
        catch (OperationCanceledException e)
        {
            Status = "Отменено";
            Logger.Warn(e, "Загрузка списка книг отменена или превысила тайм-аут");
        }
        catch (Exception e)
        {
            Status = "Ошибка";
            Logger.Error(e, "Не удалось загрузить список книг");
        }
    }
}
```

### `Books.DesktopApp/ViewModels/ViewModelBase.cs`

```csharp
﻿using ReactiveUI;

namespace Books.DesktopApp.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
}
```

### `Books.DesktopApp/Views/MainWindow.axaml`

```text
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:vm="using:Books.DesktopApp.ViewModels"
        xmlns:m="using:Books.DesktopApp.Models"
        
        x:Class="Books.DesktopApp.Views.MainWindow"
        x:DataType="vm:MainWindowViewModel"
        
        Icon="/Assets/avalonia-logo.ico"
        Title="Books.DesktopApp">

    <Design.DataContext>
        <!-- This only sets the DataContext for the previewer in an IDE,
             to set the actual DataContext for runtime, set the DataContext property in code (look at App.axaml.cs) -->
        <vm:MainWindowViewModel/>
    </Design.DataContext>
    
    <Window.Resources>
        <DataTemplate x:Key="Template_Book"
                      DataType="{x:Type TypeName=m:Book}">
            <TextBlock>
                <TextBlock.Text>
                    <MultiBinding StringFormat="#{0}: {1}">
                        <Binding Path="ShortId" 
                                 Mode="OneWay" 
                                 UpdateSourceTrigger="PropertyChanged"/>
                        <Binding Path="Title"
                                 Mode="OneWay"
                                 UpdateSourceTrigger="PropertyChanged"/>
                    </MultiBinding>
                </TextBlock.Text>
            </TextBlock>
        </DataTemplate>
    </Window.Resources>

    <DockPanel LastChildFill="True">
        <Menu DockPanel.Dock="Top">
            <MenuItem Header="Загрузить"
                      ToolTip.Tip="Загрузить данные из БД"
                      ToolTip.Placement="Bottom"
                      Command="{Binding Path=LoadCommand}"/>
        </Menu>
        
        <StackPanel Orientation="Horizontal"
                    DockPanel.Dock="Bottom">
            <ProgressBar />
            <TextBlock Text="{Binding Path=Status, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"/>
        </StackPanel>
        
        <Grid ColumnDefinitions="*, 2*">
            <ListBox ItemsSource="{Binding Path=Books}"
                     ItemTemplate="{StaticResource ResourceKey=Template_Book}"
                     SelectionMode="Single"
                     SelectedItem="{Binding Path=SelectedBook, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                     Grid.Column="0"/>
            
            <StackPanel Orientation="Vertical"
                        Grid.Column="1">
                <Grid ColumnDefinitions="*, 2.5*">
                    <Label Content="ID"
                           Target="{Binding ElementName=Input_Id}"
                           Grid.Column="0"/>
                    <TextBox x:Name="Input_Id"
                             Text="{Binding Path=Id, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"
                             IsReadOnly="True"
                             IsEnabled="False"
                             Grid.Column="1"/>
                </Grid>
                <Grid ColumnDefinitions="*, 2.5*">
                    <Label Content="Название книги"
                           Target="{Binding ElementName=Input_Book_Title}"
                           Grid.Column="0"/>
                    <TextBox x:Name="Input_Book_Title"
                             Text="{Binding Path=Title, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                             Grid.Column="1"/>
                </Grid>
                <Grid ColumnDefinitions="*, 2.5*">
                    <Label Content="Авторы"
                           Target="{Binding ElementName=Input_Book_Authors}"
                           Grid.Column="0"/>
                    <TextBox x:Name="Input_Book_Authors"
                             Text="{Binding Path=Authors, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                             Grid.Column="1"/>
                </Grid>
            </StackPanel>
        </Grid>
    </DockPanel>
</Window>
```

### `Books.DesktopApp/Views/MainWindow.axaml.cs`

```csharp
using Avalonia.Controls;

namespace Books.DesktopApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
```

### `Books.slnx`

```xml
<Solution>
  <Project Path="Books.DesktopApp/Books.DesktopApp.csproj" />
  <Project Path="Books.WebApi/Books.WebApi.csproj" />
</Solution>
```

### `Books.WebApi/appsettings.Development.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore.Database.Command": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=C:\\Programming\\Books\\books.db"
  }
}
```

### `Books.WebApi/appsettings.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### `Books.WebApi/Books.WebApi.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <Nullable>enable</Nullable>
        <ImplicitUsings>disable</ImplicitUsings>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.14" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="10.0.14" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.14">
          <PrivateAssets>all</PrivateAssets>
          <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
        <PackageReference Include="NLog.Web.AspNetCore" Version="6.2.2" />
    </ItemGroup>

    <ItemGroup>
        <None Update="NLog.config" CopyToOutputDirectory="PreserveNewest" />
    </ItemGroup>

</Project>
```

### `Books.WebApi/Books.WebApi.http`

```text
@url = http://localhost:5173

GET {{url}}/

###
```

### `Books.WebApi/Data/DataBaseContext.cs`

```csharp
using Books.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Books.WebApi.Data;

public sealed class DataBaseContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public DataBaseContext(DbContextOptions options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("table_authors");

            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id)
                .HasColumnName("id");

            entity.Property(a => a.FullName)
                .HasColumnName("full_name")
                .IsRequired();

            entity.HasIndex(a => a.FullName)
                .IsUnique()
                .HasDatabaseName("ux_table_authors_full_name");

            entity.HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    join => join.HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("book_id")
                        .HasConstraintName("fk_table_book_author_book_id"),
                    join => join.HasOne<Author>()
                        .WithMany()
                        .HasForeignKey("author_id")
                        .HasConstraintName("fk_table_book_author_author_id"),
                    join =>
                    {
                        join.ToTable("table_books_authors");
                        join.HasKey("book_id", "author_id");

                        join.Property<Guid>("book_id")
                            .HasColumnName("book_id");

                        join.Property<Guid>("author_id")
                            .HasColumnName("author_id");
                    });
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("table_books");

            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id)
                .HasColumnName("id");

            entity.Property(b => b.Title)
                .HasColumnName("title")
                .IsRequired();

            entity.HasIndex(b => b.Title)
                .HasDatabaseName("ix_table_books_title");
        });
    }
}
```

### `Books.WebApi/Data/DataBaseContextFactory.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Books.WebApi.Data;

public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
{
    public DataBaseContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlite(connectionString);
        
        return new DataBaseContext(optionsBuilder.Options);
    }
}
```

### `Books.WebApi/Migrations/20261105154202_Initial.cs`

```csharp
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "table_authors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    full_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "table_books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "table_books_authors",
                columns: table => new
                {
                    book_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    author_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_books_authors", x => new { x.book_id, x.author_id });
                    table.ForeignKey(
                        name: "fk_table_book_author_author_id",
                        column: x => x.author_id,
                        principalTable: "table_authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "fk_table_book_author_book_id",
                        column: x => x.book_id,
                        principalTable: "table_books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "ux_table_authors_full_name",
                table: "table_authors",
                column: "full_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_table_books_title",
                table: "table_books",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_table_books_authors_author_id",
                table: "table_books_authors",
                column: "author_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_books_authors");

            migrationBuilder.DropTable(
                name: "table_authors");

            migrationBuilder.DropTable(
                name: "table_books");
        }
    }
}
```

### `Books.WebApi/Migrations/20261105154202_Initial.Designer.cs`

```csharp
﻿// <auto-generated />
using System;
using Books.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Books.WebApi.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20261105154202_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.14");

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.Property<Guid>("book_id")
                        .HasColumnType("TEXT")
                        .HasColumnName("book_id");

                    b.Property<Guid>("author_id")
                        .HasColumnType("TEXT")
                        .HasColumnName("author_id");

                    b.HasKey("book_id", "author_id");

                    b.HasIndex("author_id");

                    b.ToTable("table_books_authors", (string)null);
                });

            modelBuilder.Entity("Books.WebApi.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.HasIndex("FullName")
                        .IsUnique()
                        .HasDatabaseName("ux_table_authors_full_name");

                    b.ToTable("table_authors", (string)null);
                });

            modelBuilder.Entity("Books.WebApi.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_table_books_title");

                    b.ToTable("table_books", (string)null);
                });

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.HasOne("Books.WebApi.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("author_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_table_book_author_author_id");

                    b.HasOne("Books.WebApi.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_table_book_author_book_id");
                });
#pragma warning restore 612, 618
        }
    }
}
```

### `Books.WebApi/Migrations/DataBaseContextModelSnapshot.cs`

```csharp
﻿// <auto-generated />
using System;
using Books.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Books.WebApi.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.14");

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.Property<Guid>("book_id")
                        .HasColumnType("TEXT")
                        .HasColumnName("book_id");

                    b.Property<Guid>("author_id")
                        .HasColumnType("TEXT")
                        .HasColumnName("author_id");

                    b.HasKey("book_id", "author_id");

                    b.HasIndex("author_id");

                    b.ToTable("table_books_authors", (string)null);
                });

            modelBuilder.Entity("Books.WebApi.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.HasIndex("FullName")
                        .IsUnique()
                        .HasDatabaseName("ux_table_authors_full_name");

                    b.ToTable("table_authors", (string)null);
                });

            modelBuilder.Entity("Books.WebApi.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_table_books_title");

                    b.ToTable("table_books", (string)null);
                });

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.HasOne("Books.WebApi.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_table_book_author_author_id");

                    b.HasOne("Books.WebApi.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_table_book_author_book_id");
                });
#pragma warning restore 612, 618
        }
    }
}
```

### `Books.WebApi/Models/Author.cs`

```csharp
using System;
using System.Collections.Generic;

namespace Books.WebApi.Models;

public class Author
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    
    public required string FullName { get; set; }

    public List<Book> Books { get; set; } = [];
}
```

### `Books.WebApi/Models/Book.cs`

```csharp
using System;
using System.Collections.Generic;

namespace Books.WebApi.Models;

public class Book
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public required string Title { get; set; }
    
    public List<Author> Authors { get; set; } = [];
}
```

### `Books.WebApi/Models/BookDto.cs`

```csharp
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Books.WebApi.Models;

public class BookDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; }
    
    [JsonPropertyName("title")]
    public string Title { get; }
    
    [JsonPropertyName("authors")]
    public string Authors { get; }

    public BookDto(Book book)
    {
        Id = book.Id;
        Title = book.Title;
        Authors = string.Join(", ", book.Authors.Select(a => a.FullName));
    }
}
```

### `Books.WebApi/NLog.config`

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      autoReload="true"
      throwConfigExceptions="true">
    <targets>
        <target xsi:type="File"
                name="file"
                fileName="${basedir}/logs/Books.WebApi-${shortdate}.log"
                layout="${longdate}|${level:uppercase=true}|${logger}|${message} ${exception:format=tostring}" />
        <target xsi:type="ColoredConsole"
                name="console"
                layout="${longdate}|${level:uppercase=true}|${logger}|${message} ${exception:format=tostring}">
            <highlight-row condition="level == LogLevel.Info" foregroundColor="Green" />
            <highlight-row condition="level == LogLevel.Warn" foregroundColor="Yellow" />
            <highlight-row condition="level == LogLevel.Error" foregroundColor="Red" />
            <highlight-row condition="level == LogLevel.Fatal" foregroundColor="White" backgroundColor="Red" />
        </target>
    </targets>
    <rules>
        <!-- EF предупреждения и ошибки — в файл и цветную консоль. -->
        <logger name="Microsoft.EntityFrameworkCore.*" minlevel="Warn" writeTo="file,console" final="true" />

        <!-- Остальные Info и выше, включая EF SQL-команды: в файл и цветную консоль. -->
        <logger name="*" minlevel="Info" writeTo="file,console" />
    </rules>
</nlog>
```

### `Books.WebApi/Program.cs`

```csharp
using System;
using System.Linq;
using System.Threading;
using Books.WebApi.Data;
using Books.WebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

const string apiVersion = "v1";

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException(
                           "Строка подключения 'DefaultConnection' не найдена в appsettings.json / appsettings.Development.json");

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Запуск Books.WebApi");
app.Lifetime.ApplicationStopped.Register(
    () => logger.LogInformation("Books.WebApi остановлен"));

const string baseUrl = $"/api/{apiVersion}";

var books = app.MapGroup($"{baseUrl}/books");

books.MapGet("/", async (DataBaseContext db, CancellationToken ct, ILogger<Program> logger) =>
{
    try
    {
        var items = await db.Books
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

await app.RunAsync();
```

### `Books.WebApi/Properties/launchSettings.json`

```json
﻿{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5173",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:7023;http://localhost:5173",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
