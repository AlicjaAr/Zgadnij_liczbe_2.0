using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zgadnij_liczbe;

public class Menu
{
    private Settings settings;

    private HallOfFame hallOfFame;

    public Menu()
    {
        settings = new Settings();

        hallOfFame = new HallOfFame();
    }

    public void Show()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("=== GUESS THE NUMBER 2 ===");

            Console.WriteLine("| 1. New Game             |");
            Console.WriteLine("| 2. Hall Of Fame         |");
            Console.WriteLine("| 3. Settings             |");
            Console.WriteLine("| 4. Exit                 |");
            Console.WriteLine("==========================");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartNewGame();
                    break;

                case "2":
                    hallOfFame.ShowResults();
                    break;

                case "3":
                    ShowSettings();
                    break;

                case "4":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Wrong option!");
                    break;
            }
        }
    }

    private void StartNewGame()
    {
        Console.WriteLine("1. Standard Game");
        Console.WriteLine("2. New Game Plus");

        string choice = Console.ReadLine();

        Console.WriteLine("Choose difficulty:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        string difficultyChoice = Console.ReadLine();

        int min = 1;
        int max = 100;

        switch (difficultyChoice)
        {
            case "1":
                max = 50;
                break;

            case "2":
                max = 100;
                break;

            case "3":
                max = 250;
                break;

            default:
                max = 100;
                break;
        }

        Game game;

        if (choice == "1")
        {
            game = new StandardGame(min, max, hallOfFame);
        }
        else
        {
            game = new NewGamePlus(min, max, hallOfFame);
        }

        game.StartGame();
    }

    private void ShowSettings()
    {
        Console.WriteLine($"Language: {settings.Language}");

        Console.WriteLine($"Ask for bet mode: {settings.AskForBetMode}");
    }
}