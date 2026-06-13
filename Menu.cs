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
            Messages.CurrentLanguage = settings.Language;
            
            Console.WriteLine("=== GUESS THE NUMBER 2 ===");

            Console.WriteLine("| 1. New Game             |");

            if (hallOfFame.HasResults())
            {
                Console.WriteLine("| 2. Hall Of Fame         |");
            }

            Console.WriteLine("| 3. Settings             |");
            Console.WriteLine("| 4. Exit                 |");
            Console.WriteLine("==========================");

            string choice = Console.ReadLine();

            while (choice != "1" &&
                   choice != "3" &&
                   choice != "4" &&
                   !(choice == "2" && hallOfFame.HasResults()))
            {
                Console.WriteLine("Invalid option. Please try again.");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    StartNewGame();
                    break;

                case "2":

                    if (hallOfFame.HasResults())
                    {
                        hallOfFame.ShowResults();
                    }

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
        while (choice != "1" && choice != "2")
        {
            Console.WriteLine("Please choose 1 or 2.");
            choice = Console.ReadLine();
        }

        Console.WriteLine("Choose difficulty:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        string difficultyChoice = Console.ReadLine();

        while (difficultyChoice != "1" &&
       difficultyChoice != "2" &&
       difficultyChoice != "3")
        {
            Console.WriteLine("Please choose 1, 2 or 3.");
            difficultyChoice = Console.ReadLine();
        }

        int maxAttempts = -1;

        int min = 1;
        int max = 100;

        Difficulty difficultyName = Difficulty.Medium;

        switch (difficultyChoice)
        {
            case "1":
                max = 50;
                difficultyName = Difficulty.Easy;
                break;

            case "2":
                max = 100;
                difficultyName = Difficulty.Medium;
                break;

            case "3":
                max = 250;
                difficultyName = Difficulty.Hard;
                break;

            default:
                max = 100;
                break;
        }

        if (settings.AskForBetMode)
        {
            Console.WriteLine("Do you want bet mode? (Y/N)");

            string bet = Console.ReadLine();

            while (bet.ToUpper() != "Y" &&
                bet.ToUpper() != "N")
            {
                Console.WriteLine("Please enter Y or N.");
                bet = Console.ReadLine();
            }

            if (bet.ToUpper() == "Y")
            {
                Console.WriteLine("Enter max attempts:");
                int limit;

                while (!int.TryParse(Console.ReadLine(), out limit) || limit <= 0)
                {
                    Console.WriteLine("Podaj dodatnią liczbę!");
                }

                maxAttempts = limit;
            }
        }

        Game game;

        if (choice == "1")
        {
            game = new StandardGame(min, max, hallOfFame, maxAttempts, difficultyName, false);
        }
        else
        {
            game = new NewGamePlus(min, max, hallOfFame, maxAttempts, difficultyName, true);
        }

        game.StartGame();
    }

    private void ShowSettings()
    {
        bool isSettingsOpen = true;

        while (isSettingsOpen)
        {
            Console.WriteLine("=== SETTINGS ===");

            Console.WriteLine($"Current language: {settings.Language}");

            Console.WriteLine($"Ask for bet mode: {settings.AskForBetMode}");

            Console.WriteLine();

            Console.WriteLine("1. Change language");
            Console.WriteLine("2. Toggle bet mode");
            Console.WriteLine("3. Clear Hall Of Fame");
            Console.WriteLine("4. Back");

            string choice = Console.ReadLine();

            while (choice != "1" &&
                choice != "2" &&
                choice != "3" &&
                choice != "4")
            {
                Console.WriteLine("Please choose a valid option.");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    ChangeLanguage();
                    break;

                case "2":
                    settings.AskForBetMode = !settings.AskForBetMode;
                    break;

                case "3":
                    ClearHallOfFame();
                    break;

                case "4":
                    isSettingsOpen = false;
                    break;

                default:
                    Console.WriteLine("Wrong option!");
                    break;
            }
        }
    }
    private void ChangeLanguage()
    {
        if (settings.Language == Language.PL)
        {
            settings.Language = Language.EN;
        }
        else
        {
            settings.Language = Language.PL;
        }
    }
    private void ClearHallOfFame()
    {
        Console.WriteLine("Are you sure? Y/N");

        string answer = Console.ReadLine();

        while (answer.ToUpper() != "Y" &&
            answer.ToUpper() != "N")
        {
            Console.WriteLine("Please enter Y or N.");
            answer = Console.ReadLine();
        }

        if (answer.ToUpper() == "Y")
        {
            hallOfFame.ClearResults();

            Console.WriteLine("Hall Of Fame cleared!");
        }
    }
}
