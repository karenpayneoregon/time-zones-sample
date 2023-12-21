using Spectre.Console;

namespace ExampleApp.Classes;

public class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();

        AnsiConsole.MarkupLine("[cyan]Press[/] [yellow]Enter[/][cyan] to exit[/]");

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }
}