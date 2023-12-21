using ExampleClassLibrary;
using static ExampleApp.Classes.SpectreConsoleHelpers;


namespace ExampleApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        AnsiConsole.MarkupLine("[cyan]Getting timezones[/]");

        var (list, success) = await DateTimeHelpers.TimeZones();

        // Using try/finally as I do not know the environment of who will run the code.
        try
        {
            AnsiConsole.Clear();
            if (success)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[white on red]Failed to obtain timezones[/]");
            }
        }
        finally
        {
            ExitPrompt();
        }
       
    }
}