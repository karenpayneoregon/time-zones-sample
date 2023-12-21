using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ExampleApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Time zones code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
