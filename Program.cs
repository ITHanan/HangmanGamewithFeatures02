using Figgle;
using Spectre.Console;

namespace HangmanGamewithFeatures02
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            AnsiConsole.Markup($"[bold yellow]{FiggleFonts.Standard.Render("Hangman")}[/]");
            AnsiConsole.Markup("[bold green]Welcome to Hangman![/]\n");

            HangmanGame game = new HangmanGame();
            game.Start();
        }
    }

}
