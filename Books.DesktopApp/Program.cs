using System;
using System.IO;

using Avalonia;

using NLog;

using ReactiveUI.Avalonia;

namespace Books.DesktopApp;

internal sealed class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Logger logger = LogManager.Setup()
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
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI(_ => { });
    }
}