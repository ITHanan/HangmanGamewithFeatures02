using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Spectre.Console;
using Figgle;

public interface IGame
{
    void Start();
}

public class HangmanGame : IGame
{
    private readonly List<string> wordList;
    private readonly List<char> guessedLetters;
    private string secretWord;
    private char[] guessedWord;
    private int attemptsLeft;
    private const string DataFile = "hangman_history.json";

    public HangmanGame()
    {
        wordList = new List<string> { "programming", "hangman", "developer", "console", "debugging" };
        guessedLetters = new List<char>();
    }

    public void Start()
    {
        LoadData();
        SetupGame();
        PlayGame();
        SaveData();
    }

    private void SetupGame()
    {
        Random random = new Random();
        secretWord = wordList[random.Next(wordList.Count)].ToUpper();
        guessedWord = new string('_', secretWord.Length).ToCharArray();
        attemptsLeft = 6;
        guessedLetters.Clear();
    }

    private void PlayGame()
    {
        bool isGameOver = false;

        while (!isGameOver)
        {
            Console.Clear();
            AnsiConsole.Markup($"[bold yellow]{FiggleFonts.Standard.Render("Hangman")}[/]");

            DisplayGameState();

            char guess = GetPlayerGuess();
            if (guessedLetters.Contains(guess))
            {
                AnsiConsole.Markup("[bold red]You already guessed that letter! Try again.[/]\n");
                Console.ReadKey();
                continue;
            }

            guessedLetters.Add(guess);

            if (secretWord.Contains(guess))
            {
                UpdateGuessedWord(guess);
                AnsiConsole.Markup("[bold green]Good guess![/]\n");
            }
            else
            {
                attemptsLeft--;
                AnsiConsole.Markup("[bold red]Wrong guess![/]\n");
            }

            isGameOver = CheckGameOver();
            Console.ReadKey();
        }

        if (AskToPlayAgain())
        {
            Start();
        }
    }

    private void DisplayGameState()
    {
        AnsiConsole.Markup($"[bold yellow]Word: [/] {string.Join(" ", guessedWord)}\n");
        AnsiConsole.Markup($"[bold cyan]Attempts Left:[/] [bold red]{attemptsLeft}[/]\n");
        AnsiConsole.Markup($"[bold magenta]Guessed Letters: [/][bold white]{string.Join(", ", guessedLetters)}[/]\n\n");
    }

    private char GetPlayerGuess()
    {
        Console.Write("Enter a letter: ");
        return Console.ReadLine()?.ToUpper().FirstOrDefault() ?? ' ';
    }

    private void UpdateGuessedWord(char guess)
    {
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == guess)
            {
                guessedWord[i] = guess;
            }
        }
    }

    private bool CheckGameOver()
    {
        if (!guessedWord.Contains('_'))
        {
            AnsiConsole.Markup("[bold green]Congratulations! You guessed the word![/]\n");
            AnsiConsole.Markup($"[bold yellow]The word was: {secretWord}[/]\n");
            return true;
        }

        if (attemptsLeft == 0)
        {
            AnsiConsole.Markup("[bold red]Game Over! You've run out of attempts![/]\n");
            AnsiConsole.Markup($"[bold yellow]The word was: {secretWord}[/]\n");
            return true;
        }

        return false;
    }

    private bool AskToPlayAgain()
    {
        Console.Write("Play again? (y/n): ");
        char playAgain = Console.ReadLine()?.ToLower().FirstOrDefault() ?? 'n';
        return playAgain == 'y';
    }

    private void SaveData()
    {
        try
        {
            string DataFile = "Data.json";
            string json = JsonSerializer.Serialize(wordList);
            File.WriteAllText(DataFile, json);
            AnsiConsole.Markup("[bold green]Game history saved successfully.[/]\n");
        }
        catch (Exception ex)
        {
            AnsiConsole.Markup($"[bold red]Failed to save game history: {ex.Message}[/]\n");
        }
    }

    private void LoadData()
    {
        try
        {
            if (File.Exists("Data.json"))
            {
                string json = File.ReadAllText(DataFile);
                wordList.AddRange(JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>());
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.Markup($"[bold red]Failed to load game history: {ex.Message}[/]\n");
        }
    }
}
