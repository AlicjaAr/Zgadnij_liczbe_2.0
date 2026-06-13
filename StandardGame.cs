using System;
using Zgadnij_liczbe;

public class StandardGame : Game
{
    public StandardGame(int min, int max, HallOfFame hallOfFame, int maxAttempts, Difficulty difficulty, bool isNewGamePlus)
        : base(min, max, hallOfFame, maxAttempts, difficulty, false)
    {
    }

    public override void StartGame()
    {
        GenerateNumber();

        timer.Start();

        bool isPlaying = true;

        while (isPlaying)
        {
            if (maxAttempts != -1 && attempts >= maxAttempts)
            {
                Console.WriteLine(Messages.Get("Lose"));
                isPlaying = false;
                return;
            }

            attempts++;

            Console.WriteLine($ {Messages.Get("AttemptsLeft")}: {attempts});

            int guess;

            while (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.WriteLine("Please enter a valid number!");
            }

            if (guess == hiddenNumber)
            {
                timer.Stop();

                Console.WriteLine(Messages.Get("Win"));
                Console.WriteLine(Messages.Get("EnterName"));

                string playerName = Console.ReadLine();

                Result result = new Result();

                result.PlayerName = playerName;

                result.Attempts = attempts;

                result.TimeInSeconds = (int)timer.Elapsed.TotalSeconds;

                result.Difficulty = difficulty;

                result.IsNewGamePlus = isNewGamePlus;

                hallOfFame.AddResult(result);

                isPlaying = false;
            }
            else if (guess < hiddenNumber)
            {
                Console.WriteLine(Messages.GetTooLow());
            }
            else
            {
                Console.WriteLine(Messages.GetTooHigh());
            }
        }
    }
}
